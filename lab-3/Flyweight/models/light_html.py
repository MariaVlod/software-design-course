from models.light_node import LightElementNode, LightTextNode

class LightHTML:
    def __init__(self, content):
        self.content = content
        self.parsed_data = []

    def parse_book(self):
        lines = self.content.split('\n')
        for i, line in enumerate(lines):
            original_line = line
            line = line.strip()

            if not line:
                continue

            if i == 0:
                element = LightElementNode('h1', is_block=True)
            elif original_line.startswith((' ', '\t')):
                element = LightElementNode('blockquote', is_block=True)
            elif len(line) < 20:
                element = LightElementNode('h2', is_block=True)
            else:
                element = LightElementNode('p', is_block=True)

            element.add_child(LightTextNode(line))
            self.parsed_data.append(element)

    def get_html(self):
        return '\n'.join(element.render() for element in self.parsed_data)
