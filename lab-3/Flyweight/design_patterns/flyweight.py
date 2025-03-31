from models.light_node import LightElementNode, LightTextNode

class HTMLElementFactory:
    _elements = {}

    @classmethod
    def get_element(cls, tag_name, display_type='block', closing_type='pair', css_classes=None):
        key = (tag_name, display_type, closing_type, tuple(css_classes) if css_classes else ())
        if key not in cls._elements:
            cls._elements[key] = LightElementNode(tag_name, display_type, closing_type, css_classes)
        return cls._elements[key]

    @classmethod
    def get_text_node(cls, text):
        return LightTextNode(text)

    @classmethod
    def get_cached_elements(cls):
        return cls._elements