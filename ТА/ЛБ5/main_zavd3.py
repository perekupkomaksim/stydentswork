import re
from collections import Counter

text = """
Python - це високорівнева мова програмування загального призначення. 
Python підтримує структурне, об'єктно-орієнтоване, функціональне, 
imperативне та аспектно-орієнтоване програмування. Основні архітектурні 
риси Python - динамічна типізація, автоматичне управління пам'яттю, 
повна інтроспекція, механізм обробки винятків, підтримка багатопотокових 
обчислень. Python використовується в багатьох областях, включаючи 
веб-розробку, наукові обчислення, аналіз даних та машинне навчання.
"""

print("=" * 70)
print("АНАЛІЗ ТЕКСТУ")
print("=" * 70)
print(f"\nВхідний текст:\n{text[:200]}...\n")

print("=" * 70)
print("1. СПИСОК СЛІВ")
print("=" * 70)

clean_text = text.lower()
clean_text = re.sub(r'[.,!?;:""\'()—\-]', ' ', clean_text)
words_list = [word for word in clean_text.split() if word]

print(f"Список слів (перші 15):")
print(words_list[:15])
print(f"\nЗагальна кількість слів у списку: {len(words_list)}")

print("\n" + "=" * 70)
print("2. МНОЖИНА УНІКАЛЬНИХ СЛІВ")
print("=" * 70)

unique_words = set(words_list)

print(f"Унікальні слова (перші 15):")
print(sorted(list(unique_words))[:15])
print(f"\nКількість унікальних слів: {len(unique_words)}")

print("\n" + "=" * 70)
print("3. КОРТЕЖ СЛІВ, ВІДСОРТОВАНИХ ЗА ДОВЖИНОЮ")
print("=" * 70)

sorted_by_length = tuple(sorted(unique_words, key=lambda x: (len(x), x)))

print("Найкоротші слова:")
print(sorted_by_length[:10])
print("\nНайдовші слова:")
print(sorted_by_length[-10:])

from itertools import groupby
length_groups = {}
for length, group in groupby(sorted_by_length, key=len):
    length_groups[length] = list(group)

print(f"\nРозподіл за довжиною:")
for length in sorted(length_groups.keys())[:5]:
    print(f"  {length} символів: {len(length_groups[length])} слів - {length_groups[length][:3]}")

print("\n" + "=" * 70)
print("4. СЛОВНИК ЧАСТОТ ПОЯВИ СЛІВ")
print("=" * 70)

frequency_dict = {}
for word in words_list:
    frequency_dict[word] = frequency_dict.get(word, 0) + 1

frequency_counter = Counter(words_list)

print("Частоти слів (перші 10):")
for word, count in sorted(frequency_dict.items(), key=lambda x: x[1], reverse=True)[:10]:
    print(f"  '{word}': {count}")

print("\n" + "=" * 70)
print("5. СТАТИСТИКА")
print("=" * 70)

total_words = len(words_list)
unique_count = len(unique_words)
uniqueness_percent = (unique_count / total_words) * 100

print(f"\nЗАГАЛЬНА СТАТИСТИКА:")
print(f" - Загальна кількість слів: {total_words}")
print(f" - Унікальних слів: {unique_count}")
print(f" - Унікальність тексту: {uniqueness_percent:.1f}%")
print(f" - Середня довжина слова: {sum(len(w) for w in words_list) / total_words:.2f} символів")

top_5 = frequency_counter.most_common(5)

print(f"\nТОП-5 НАЙЧАСТІШИХ СЛІВ:")
for i, (word, count) in enumerate(top_5, 1):
    percentage = (count / total_words) * 100
    bar = "#" * int(percentage * 2)
    print(f"   {i}. '{word}': {count} разів ({percentage:.1f}%) {bar}")

print(f"\nДОДАТКОВА СТАТИСТИКА:")
words_once = sum(1 for count in frequency_dict.values() if count == 1)
print(f" - Слів, що з'являються 1 раз: {words_once}")
print(f" - Найдовше слово: '{max(unique_words, key=len)}' ({len(max(unique_words, key=len))} символів)")
print(f" - Найкоротше слово: '{min(unique_words, key=len)}' ({len(min(unique_words, key=len))} символів)")

print("\n" + "=" * 70)
print("БОНУС: ПЕРЕТВОРЕННЯ МІЖ СТРУКТУРАМИ ДАНИХ")
print("=" * 70)

print("\n1. Список → Множина (видалення дублікатів):")
sample_list = ['python', 'java', 'python', 'c++', 'java']
print(f"   Список: {sample_list}")
print(f"   Множина: {set(sample_list)}")

print("\n2. Множина → Список → Кортеж:")
sample_set = {'a', 'b', 'c'}
print(f"   Множина: {sample_set}")
print(f"   Список: {list(sample_set)}")
print(f"   Кортеж: {tuple(sample_set)}")

print("\n3. Словник → Список пар → Словник:")
sample_dict = {'x': 1, 'y': 2, 'z': 3}
print(f"   Словник: {sample_dict}")
print(f"   Список items: {list(sample_dict.items())}")
print(f"   Назад у словник: {dict(list(sample_dict.items()))}")

print("\n4. Створення словника з списків:")
keys = ['name', 'age', 'city']
values = ['Ivan', 25, 'Kyiv']
person = dict(zip(keys, values))
print(f"   Ключі: {keys}")
print(f"   Значення: {values}")
print(f"   Словник: {person}")

print("\n" + "=" * 70)
print("АНАЛІЗ ЗАВЕРШЕНО")
print("=" * 70)
