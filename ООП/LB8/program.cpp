#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

class Pair {
protected:
    int first;
    int second;

public:
    Pair() : first(0), second(0) {
        cout << "Pair(): Створено пару (0, 0)" << endl;
    }
    
    Pair(int f, int s) : first(f), second(s) {
        cout << "Pair(" << f << ", " << s << "): Створено пару" << endl;
    }
    
    Pair(const Pair& other) : first(other.first), second(other.second) {
        cout << "Pair(copy): Копіювання пари (" << first << ", " << second << ")" << endl;
    }
    
    virtual ~Pair() {
        cout << "~Pair(): Видалення пари (" << first << ", " << second << ")" << endl;
    }
    
    void setFirst(int f) {
        first = f;
    }
    
    void setSecond(int s) {
        second = s;
    }
    
    void setPair(int f, int s) {
        first = f;
        second = s;
    }
    
    int getFirst() const {
        return first;
    }
    
    int getSecond() const {
        return second;
    }
    
    virtual Pair* add(const Pair& other) const {
        return new Pair(first + other.first, second + other.second);
    }
    
    Pair operator+(const Pair& other) const {
        return Pair(first + other.first, second + other.second);
    }
    
    virtual void print() const {
        cout << "Pair(" << first << ", " << second << ")";
    }
    
    friend ostream& operator<<(ostream& os, const Pair& p) {
        os << "(" << p.first << ", " << p.second << ")";
        return os;
    }
};

class Long : public Pair {
private:
    
public:
    Long() : Pair(0, 0) {
        cout << "Long(): Створено число 0" << endl;
    }
    
    Long(int high, int low) : Pair(high, low) {
        cout << "Long(" << high << ", " << low << "): Створено довге число" << endl;
    }
    
    Long(long long value) {
        first = value / 10000;
        second = value % 10000;
        cout << "Long(" << value << "): Створено довге число [" 
             << first << ", " << second << "]" << endl;
    }
    
    Long(const Long& other) : Pair(other) {
        cout << "Long(copy): Копіювання довгого числа" << endl;
    }
    
    ~Long() {
        cout << "~Long(): Видалення довгого числа [" << first << ", " << second << "]" << endl;
    }
    
    void setHigh(int h) {
        first = h;
    }
    
    void setLow(int l) {
        second = l;
    }
    
    long long getValue() const {
        return (long long)first * 10000 + second;
    }
    
    virtual Pair* add(const Pair& other) const override {
        const Long* otherLong = dynamic_cast<const Long*>(&other);
        
        if (otherLong) {
            long long val1 = this->getValue();
            long long val2 = otherLong->getValue();
            long long result = val1 + val2;
            
            return new Long(result);
        } else {
            return new Long(first + other.getFirst(), second + other.getSecond());
        }
    }
    
    Long operator+(const Long& other) const {
        long long val1 = this->getValue();
        long long val2 = other.getValue();
        return Long(val1 + val2);
    }
    
    Long multiply(const Long& other) const {
        long long val1 = this->getValue();
        long long val2 = other.getValue();
        return Long(val1 * val2);
    }
    
    Long operator*(const Long& other) const {
        return multiply(other);
    }
    
    Long subtract(const Long& other) const {
        long long val1 = this->getValue();
        long long val2 = other.getValue();
        return Long(val1 - val2);
    }
    
    Long operator-(const Long& other) const {
        return subtract(other);
    }
    
    virtual void print() const override {
        cout << "Long[" << first << ", " << second << "] = " << getValue();
    }
    
    friend ostream& operator<<(ostream& os, const Long& l) {
        os << "Long[" << l.first << ", " << l.second << "] = " << l.getValue();
        return os;
    }
};

void processPair(const Pair& p) {
    cout << "\n--- processPair (приймає Pair&) ---" << endl;
    cout << "Отримано об'єкт: ";
    p.print();
    cout << endl;
    cout << "Перше значення: " << p.getFirst() << endl;
    cout << "Друге значення: " << p.getSecond() << endl;
}

Pair createPair(int f, int s) {
    cout << "\n--- createPair (повертає Pair) ---" << endl;
    return Pair(f, s);
}

void processPairPointer(Pair* p) {
    cout << "\n--- processPairPointer (приймає Pair*) ---" << endl;
    if (p) {
        cout << "Отримано об'єкт через вказівник: ";
        p->print();
        cout << endl;
    }
}

void demonstrateAddition(Pair* p1, Pair* p2) {
    cout << "\n--- demonstrateAddition (працює з Pair*) ---" << endl;
    cout << "Перший об'єкт: ";
    p1->print();
    cout << endl;
    
    cout << "Другий об'єкт: ";
    p2->print();
    cout << endl;
    
    cout << "Виконуємо додавання через віртуальний метод add()..." << endl;
    Pair* result = p1->add(*p2);
    
    cout << "Результат: ";
    result->print();
    cout << endl;
    
    delete result;
}

void processArray(Pair** array, int size) {
    cout << "\n--- processArray (масив Pair*) ---" << endl;
    for (int i = 0; i < size; i++) {
        cout << "Елемент " << i << ": ";
        array[i]->print();
        cout << endl;
    }
}

int main() {
    cout << "========================================================" << endl;
    cout << "ДЕМОНСТРАЦІЯ КЛАСІВ PAIR І LONG" << endl;
    cout << "ПРИНЦИП ПІДСТАНОВКИ ЛІСКОВ (LSP)" << endl;
    cout << "========================================================" << endl;
    
    cout << "\n\n### ЧАСТИНА 1: Робота з класом Pair ###\n" << endl;
    
    Pair p1(5, 10);
    Pair p2(3, 7);
    
    cout << "\nПара p1: " << p1 << endl;
    cout << "Пара p2: " << p2 << endl;
    
    cout << "\nДодавання пар: p1 + p2" << endl;
    Pair p3 = p1 + p2;
    cout << "Результат p3: " << p3 << endl;
    
    cout << "\nЗміна значень p1:" << endl;
    p1.setFirst(8);
    p1.setSecond(12);
    cout << "Нова пара p1: " << p1 << endl;
    
    cout << "\n\n### ЧАСТИНА 2: Робота з класом Long ###\n" << endl;
    
    Long l1(2, 5000);
    Long l2(1, 3000);
    
    cout << "\nДовге число l1: ";
    l1.print();
    cout << endl;
    
    cout << "Довге число l2: ";
    l2.print();
    cout << endl;
    
    cout << "\n--- Операція додавання ---" << endl;
    Long l3 = l1 + l2;
    cout << "l1 + l2 = ";
    l3.print();
    cout << endl;
    
    cout << "\n--- Операція множення ---" << endl;
    Long l4 = l1 * l2;
    cout << "l1 * l2 = ";
    l4.print();
    cout << endl;
    
    cout << "\n--- Операція віднімання ---" << endl;
    Long l5 = l1 - l2;
    cout << "l1 - l2 = ";
    l5.print();
    cout << endl;
    
    cout << "\n\n### ЧАСТИНА 3: Демонстрація принципу підстановки ###" << endl;
    
    cout << "\n--- 3.1: Передача різних об'єктів у функцію ---" << endl;
    processPair(p1);
    processPair(l1);
    
    cout << "\n--- 3.2: Поліморфізм через вказівники ---" << endl;
    Pair* ptr1 = &p1;
    Pair* ptr2 = &l1;
    
    processPairPointer(ptr1);
    processPairPointer(ptr2);
    
    cout << "\n--- 3.3: Віртуальне додавання ---" << endl;
    cout << "\nДодавання двох Pair:" << endl;
    demonstrateAddition(&p1, &p2);
    
    cout << "\nДодавання двох Long:" << endl;
    demonstrateAddition(&l1, &l2);
    
    cout << "\nДодавання Pair і Long:" << endl;
    demonstrateAddition(&p1, &l1);
    
    cout << "\n--- 3.4: Масив об'єктів базового класу ---" << endl;
    Pair* array[4];
    array[0] = new Pair(1, 2);
    array[1] = new Long(3, 4000);
    array[2] = new Pair(5, 6);
    array[3] = new Long(7, 8000);
    
    processArray(array, 4);
    
    cout << "\nВидалення об'єктів з масиву:" << endl;
    for (int i = 0; i < 4; i++) {
        delete array[i];
    }
    
    cout << "\n--- 3.5: Динамічне приведення типів ---" << endl;
    Pair* dynamicPtr = new Long(5, 6000);
    
    cout << "Створено Long, збережений як Pair*: ";
    dynamicPtr->print();
    cout << endl;
    
    Long* longPtr = dynamic_cast<Long*>(dynamicPtr);
    if (longPtr) {
        cout << "dynamic_cast успішний! Це дійсно Long." << endl;
        cout << "Значення: " << longPtr->getValue() << endl;
    } else {
        cout << "Це не Long." << endl;
    }
    
    delete dynamicPtr;
    
    cout << "\n\n========================================================" << endl;
    cout << "ПІДСУМКИ ДЕМОНСТРАЦІЇ:" << endl;
    cout << "========================================================" << endl;
    cout << "✓ Створено базовий клас Pair з операцією додавання" << endl;
    cout << "✓ Створено клас-спадкоємець Long з перевизначеним додаванням" << endl;
    cout << "✓ Реалізовано методи множення та віднімання в Long" << endl;
    cout << "✓ Продемонстровано принцип підстановки (LSP):" << endl;
    cout << "  - Об'єкти Long можна використовувати замість Pair" << endl;
    cout << "  - Віртуальні функції працюють поліморфно" << endl;
    cout << "  - Функції приймають та повертають базовий клас" << endl;
    cout << "========================================================\n" << endl;
    
    return 0;
}
