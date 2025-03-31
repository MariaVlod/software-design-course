from models.light_node import LightNode

class LightElementNode(LightNode):
    def __init__(self, tag_name, display_type, self_closing=False, css_classes=None, attributes=None):
        self.tag_name = tag_name
        self.display_type = display_type
        self.self_closing = self_closing
        self.css_classes = css_classes if css_classes else []
        self.attributes = attributes if attributes else {}
        self.children = []

    def add_class(self, css_class):
        self.css_classes.append(css_class)

    def add_attribute(self, key, value):
        self.attributes[key] = value

    def add_child(self, child):
        self.children.append(child)

    def render(self):
        class_attr = f' class="{" ".join(self.css_classes)}"' if self.css_classes else ""
        other_attrs = " ".join(f'{k}="{v}"' for k, v in self.attributes.items())
        attributes = f"{class_attr} {other_attrs}".strip()
        start_tag = f"<{self.tag_name} {attributes}>".strip()
        end_tag = f"</{self.tag_name}>" if not self.self_closing else ""

        content = ''.join(child.render() for child in self.children)

        return start_tag + content + end_tag

    def outer_html(self):
        return self.render()

    def inner_html(self):
        return ''.join(child.render() for child in self.children)
