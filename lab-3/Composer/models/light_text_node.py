from models.light_node import LightNode
import re

class LightTextNode(LightNode):
    def __init__(self, text):
        if re.search(r"<[^>]+>", text):
            raise ValueError("Текстовий вузол не може містити HTML-теги!")
        self.text = text

    def render(self):
        return self.text
