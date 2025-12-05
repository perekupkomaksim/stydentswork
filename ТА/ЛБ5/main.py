# Створення списку
L = [3, 1, 4, 1, 5]
print("Початковий список:", L)

# Доступ до елементів
print("Перший елемент:", L[0])
print("Останній елемент:", L[-1])

# Додавання елементів
L.append(9)
print("Після append(9):", L)

L.extend([2, 6])
print("Після extend([2, 6]):", L)

L.insert(0, 0)
print("Після insert(0, 0):", L)

# Видалення елементів
L.remove(1)  # видаляє перше входження 1
print("Після remove(1):", L)

deleted = L.pop()  # видаляє останній елемент
print(f"Після pop() (видалено {deleted}):", L)

del L[0]  # видаляє елемент за індексом
print("Після del L[0]:", L)

# Сортування
L_copy = L.copy()
L_copy.sort()
print("Відсортований список:", L_copy)

L_copy.reverse()
print("Перевернутий список:", L_copy)

# Довжина
print("Довжина списку:", len(L))

# Slicing (зрізи)
test_list = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
print("\nПриклади slicing:")
print("test_list[2:5]:", test_list[2:5])
print("test_list[:3]:", test_list[:3])
print("test_list[7:]:", test_list[7:])
print("test_list[::2]:", test_list[::2])
print("test_list[::-1]:", test_list[::-1])

# Перетворення
print("\nПеретворення:")
print("list(tuple(L)):", list(tuple(L)))
print("list(set(L)):", list(set(L)))