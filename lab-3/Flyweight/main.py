from models.light_html import LightHTML
from services.book_parser import load_book_text
from utils.memory_usage import measure_memory_usage

if __name__ == '__main__':
    print("Завантаження книги...")
    book_text = load_book_text('data/book.txt')

    print("Парсинг тексту...")
    html_builder = LightHTML(book_text)
    html_builder.parse_book()

    print("Генерація HTML...")
    html_output = html_builder.get_html()

    print("\n--- HTML ---")
    print(html_output)

    memory = measure_memory_usage(html_builder)
    print(f"\nВикористання памʼяті: {memory / 1024 / 1024:.2f} MB")
