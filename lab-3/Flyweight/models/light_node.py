class LightNode:
    def __init__(self):
        self.children = []

    def add_child(self, child):
        self.children.append(child)

class LightTextNode(LightNode):
    def __init__(self, text):
        super().__init__()
        self.text = text

    def render(self):
        return self.text

class LightElementNode(LightNode):
    def __init__(self, tag_name, is_block, self_closing=False):
        super().__init__()
        self.tag_name = tag_name
        self.is_block = is_block
        self.self_closing = self_closing
        self.css_classes = []

    def add_class(self, css_class):
        self.css_classes.append(css_class)

    def render(self):
        start_tag = f"<{self.tag_name}>"
        if self.self_closing:
            start_tag = f"<{self.tag_name}/>"
        end_tag = f"</{self.tag_name}>"
        content = ''.join(child.render() for child in self.children)
        return start_tag + content + end_tag if not self.self_closing else start_tag
