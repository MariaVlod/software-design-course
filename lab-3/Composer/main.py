from services.page_generator import create_sample_page, create_sample_table

if __name__ == '__main__':
    print("Створення сторінки...")

    page = create_sample_page()
    table = create_sample_table()

    print("\n--- Outer HTML (список) ---")
    print(page.outer_html())

    print("\n--- Inner HTML (список) ---")
    print(page.inner_html())

    print("\n--- Outer HTML (таблиця) ---")
    print(table.outer_html())

    print("\n--- Inner HTML (таблиця) ---")
    print(table.inner_html())
