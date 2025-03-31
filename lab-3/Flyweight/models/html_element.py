class HTMLElement:
    def __init__(self, tag_name):
        self.tag_name = tag_name

    def wrap_content(self, content):
        return f"<{self.tag_name}>{content}</{self.tag_name}>"
