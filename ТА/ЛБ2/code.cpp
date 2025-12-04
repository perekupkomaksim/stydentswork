#include <iostream>
#include <vector>
#include <algorithm>
#include <iomanip>
using namespace std;

// Функція для виведення масиву
void printArray(const vector<int>& arr) {
    cout << "[";
    for (size_t i = 0; i < arr.size(); i++) {
        cout << arr[i];
        if (i < arr.size() - 1) cout << ", ";
    }
    cout << "]" << endl;
}

// Функція для виведення розділювача
void printSeparator(char ch = '=', int length = 60) {
    cout << string(length, ch) << endl;
}

// ==================== ЛІНІЙНИЙ ПОШУК ====================
void linearSearch(const vector<int>& arr, int target) {
    printSeparator();
    cout << "ЛІНІЙНИЙ ПОШУК" << endl;
    printSeparator();
    cout << "Масив: ";
    printArray(arr);
    cout << "Шуканий елемент: " << target << endl;
    printSeparator('-');
    
    int comparisons = 0;
    
    for (size_t i = 0; i < arr.size(); i++) {
        comparisons++;
        cout << "Крок " << comparisons << ": ";
        cout << "arr[" << i << "] = " << arr[i];
        
        if (arr[i] == target) {
            cout << " == " << target << " -> ЗНАЙДЕНО!" << endl;
            printSeparator('-');
            cout << "Результат: Елемент знайдено на позиції " << i << endl;
            cout << "Кількість порівнянь: " << comparisons << endl;
            printSeparator();
            return;
        } else {
            cout << " != " << target << endl;
        }
    }
    
    printSeparator('-');
    cout << "Результат: Елемент не знайдено" << endl;
    cout << "Кількість порівнянь: " << comparisons << endl;
    printSeparator();
}

// ==================== ДВІЙКОВИЙ ПОШУК ====================
void binarySearch(vector<int> arr, int target) {
    printSeparator();
    cout << "ДВІЙКОВИЙ ПОШУК" << endl;
    printSeparator();
    
    // Спочатку сортуємо масив
    sort(arr.begin(), arr.end());
    cout << "Відсортований масив: ";
    printArray(arr);
    cout << "Шуканий елемент: " << target << endl;
    printSeparator('-');
    
    int left = 0;
    int right = arr.size() - 1;
    int comparisons = 0;
    
    while (left <= right) {
        int mid = left + (right - left) / 2;
        comparisons++;
        
        cout << "Крок " << comparisons << ": ";
        cout << "left=" << left << ", mid=" << mid << ", right=" << right << endl;
        cout << "  arr[" << mid << "] = " << arr[mid] << " vs " << target;
        
        if (arr[mid] == target) {
            cout << " -> ЗНАЙДЕНО!" << endl;
            printSeparator('-');
            cout << "Результат: Елемент знайдено на позиції " << mid << endl;
            cout << "Кількість порівнянь: " << comparisons << endl;
            printSeparator();
            return;
        }
        
        if (arr[mid] < target) {
            cout << " -> arr[mid] < target, шукаємо праворуч" << endl;
            left = mid + 1;
        } else {
            cout << " -> arr[mid] > target, шукаємо ліворуч" << endl;
            right = mid - 1;
        }
    }
    
    printSeparator('-');
    cout << "Результат: Елемент не знайдено" << endl;
    cout << "Кількість порівнянь: " << comparisons << endl;
    printSeparator();
}

// ==================== СОРТУВАННЯ БУЛЬБАШКОЮ ====================
void bubbleSort(vector<int> arr) {
    printSeparator();
    cout << "СОРТУВАННЯ МЕТОДОМ БУЛЬБАШКИ" << endl;
    printSeparator();
    cout << "Початковий масив: ";
    printArray(arr);
    printSeparator('-');
    
    int n = arr.size();
    int swaps = 0;
    int comparisons = 0;
    
    for (int i = 0; i < n - 1; i++) {
        cout << "\n=== ПРОХІД " << (i + 1) << " ===" << endl;
        bool swapped = false;
        
        for (int j = 0; j < n - i - 1; j++) {
            comparisons++;
            cout << "Порівняння: arr[" << j << "]=" << arr[j] 
                 << " і arr[" << j+1 << "]=" << arr[j+1];
            
            if (arr[j] > arr[j + 1]) {
                cout << " -> ОБМІН" << endl;
                cout << "  До:    ";
                printArray(arr);
                
                swap(arr[j], arr[j + 1]);
                swaps++;
                swapped = true;
                
                cout << "  Після: ";
                printArray(arr);
            } else {
                cout << " -> без обміну" << endl;
            }
        }
        
        cout << "Результат проходу " << (i + 1) << ": ";
        printArray(arr);
        cout << "Статистика: Порівнянь=" << comparisons 
             << ", Обмінів=" << swaps << endl;
        
        if (!swapped) {
            cout << "\nМасив відсортовано (немає обмінів у проході)" << endl;
            break;
        }
    }
    
    printSeparator('-');
    cout << "\nВідсортований масив: ";
    printArray(arr);
    cout << "ЗАГАЛЬНА СТАТИСТИКА:" << endl;
    cout << "  Всього порівнянь: " << comparisons << endl;
    cout << "  Всього обмінів: " << swaps << endl;
    printSeparator();
}

// ==================== ШВИДКЕ СОРТУВАННЯ ====================
class QuickSort {
private:
    int comparisons;
    int swaps;
    
    void printIndent(int depth) {
        for (int i = 0; i < depth; i++) cout << "  ";
    }
    
    int partition(vector<int>& arr, int low, int high, int depth) {
        int pivot = arr[high];
        printIndent(depth);
        cout << "Розділення підмасиву [" << low << "..." << high << "]";
        cout << ", опорний елемент: " << pivot << endl;
        
        int i = low - 1;
        
        for (int j = low; j < high; j++) {
            comparisons++;
            if (arr[j] < pivot) {
                i++;
                if (i != j) {
                    printIndent(depth);
                    cout << "Обмін: arr[" << i << "]=" << arr[i] 
                         << " <-> arr[" << j << "]=" << arr[j] << endl;
                    swap(arr[i], arr[j]);
                    swaps++;
                    
                    printIndent(depth);
                    cout << "Стан: ";
                    printArray(arr);
                }
            }
        }
        
        printIndent(depth);
        cout << "Розміщення опорного: arr[" << (i+1) << "]=" << arr[i+1] 
             << " <-> arr[" << high << "]=" << arr[high] << endl;
        swap(arr[i + 1], arr[high]);
        swaps++;
        
        printIndent(depth);
        cout << "Після розділення: ";
        printArray(arr);
        printIndent(depth);
        cout << "Статистика: Порівнянь=" << comparisons 
             << ", Обмінів=" << swaps << endl;
        
        return i + 1;
    }
    
    void quickSortRecursive(vector<int>& arr, int low, int high, int depth) {
        if (low < high) {
            int pi = partition(arr, low, high, depth);
            quickSortRecursive(arr, low, pi - 1, depth + 1);
            quickSortRecursive(arr, pi + 1, high, depth + 1);
        }
    }
    
public:
    void sort(vector<int> arr) {
        printSeparator();
        cout << "ШВИДКЕ СОРТУВАННЯ (QUICKSORT)" << endl;
        printSeparator();
        cout << "Початковий масив: ";
        printArray(arr);
        printSeparator('-');
        
        comparisons = 0;
        swaps = 0;
        
        quickSortRecursive(arr, 0, arr.size() - 1, 0);
        
        printSeparator('-');
        cout << "\nВідсортований масив: ";
        printArray(arr);
        cout << "ЗАГАЛЬНА СТАТИСТИКА:" << endl;
        cout << "  Всього порівнянь: " << comparisons << endl;
        cout << "  Всього обмінів: " << swaps << endl;
        printSeparator();
    }
};

// ==================== ГОЛОВНЕ МЕНЮ ====================
void printMenu() {
    printSeparator('*');
    cout << "*" << setw(59) << "*" << endl;
    cout << "*    АЛГОРИТМИ ПОШУКУ ТА СОРТУВАННЯ    *" << endl;
    cout << "*" << setw(59) << "*" << endl;
    printSeparator('*');
    cout << "1. Лінійний пошук" << endl;
    cout << "2. Двійковий пошук" << endl;
    cout << "3. Сортування бульбашкою" << endl;
    cout << "4. Швидке сортування" << endl;
    cout << "5. Ввести новий масив" << endl;
    cout << "0. Вихід" << endl;
    printSeparator('*');
    cout << "Ваш вибір: ";
}

// Функція для введення масиву
vector<int> inputArray() {
    vector<int> arr;
    int n;
    
    cout << "\nВведення масиву" << endl;
    printSeparator('-');
    cout << "Кількість елементів: ";
    cin >> n;
    
    cout << "Введіть " << n << " елементів (через пробіл або Enter):" << endl;
    for (int i = 0; i < n; i++) {
        int value;
        cin >> value;
        arr.push_back(value);
    }
    
    cout << "Введений масив: ";
    printArray(arr);
    
    return arr;
}

// ==================== ГОЛОВНА ФУНКЦІЯ ====================
int main() {
    // Встановлення української локалі для коректного виведення
    setlocale(LC_ALL, "uk_UA.UTF-8");
    
    // Початковий масив за замовчуванням
    vector<int> arr = {64, 34, 25, 12, 22, 11, 90};
    
    int choice;
    
    cout << "\nПоточний масив: ";
    printArray(arr);
    cout << endl;
    
    while (true) {
        printMenu();
        cin >> choice;
        cout << endl;
        
        if (choice == 0) {
            cout << "Дякуємо за використання програми!" << endl;
            break;
        }
        
        switch (choice) {
            case 1: {
                int target;
                cout << "Введіть елемент для пошуку: ";
                cin >> target;
                cout << endl;
                linearSearch(arr, target);
                break;
            }
            
            case 2: {
                int target;
                cout << "Введіть елемент для пошуку: ";
                cin >> target;
                cout << endl;
                binarySearch(arr, target);
                break;
            }
            
            case 3: {
                bubbleSort(arr);
                break;
            }
            
            case 4: {
                QuickSort qs;
                qs.sort(arr);
                break;
            }
            
            case 5: {
                arr = inputArray();
                cout << endl;
                break;
            }
            
            default:
                cout << "Невірний вибір! Спробуйте ще раз." << endl << endl;
        }
        
        if (choice >= 1 && choice <= 4) {
            cout << "\nНатисніть Enter для продовження...";
            cin.ignore();
            cin.get();
            cout << endl;
        }
    }
    
    return 0;
}
