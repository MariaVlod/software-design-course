from models.light_element_node import LightElementNode
from models.light_text_node import LightTextNode

def create_sample_page():
    ul = LightElementNode('ul', display_type='block')

    for i in range(1, 4):
        li = LightElementNode('li', display_type='inline')
        li.add_child(LightTextNode(f'Елемент {i}'))
        ul.add_child(li)

    return ul

def create_sample_table():
    table = LightElementNode('table', display_type='block')
    table.add_attribute("border", "1")

    for i in range(3):
        tr = LightElementNode('tr', display_type='block')
        for j in range(3):
            td = LightElementNode('td', display_type='inline')
            td.add_child(LightTextNode(f"({i}, {j})"))
            tr.add_child(td)
        table.add_child(tr)

    return table
