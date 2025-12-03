#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

double f(double x) {
    return 2 * x * x - x * x * x + 0.2;
}

double df(double x) {
    return 4 * x - 3 * x * x;
}

double d2f(double x) {
    return 4 - 6 * x;
}

void combinedMethod(double a, double b, double epsilon, int maxIter = 100) {
    double fa = f(a);
    double fb = f(b);
    
    if (fa * fb > 0) {
        cout << "Помилка: Функція повинна мати різні знаки на кінцях інтервалу!" << endl;
        return;
    }
    
    bool newtonFromA = (fa * d2f(a) > 0);
    
    cout << "\nВизначення методів для кінців інтервалу:" << endl;
    cout << "f(a) * f''(a) = " << fa * d2f(a) << endl;
    if (newtonFromA) {
        cout << "Метод Ньютона застосовується до точки a" << endl;
        cout << "Метод хорд застосовується до точки b" << endl;
    } else {
        cout << "Метод хорд застосовується до точки a" << endl;
        cout << "Метод Ньютона застосовується до точки b" << endl;
    }
    cout << endl;
    
    cout << left << setw(10) << "Ітерація" 
         << setw(14) << "a" 
         << setw(14) << "b" 
         << setw(14) << "|b - a|"
         << setw(14) << "f(a)"
         << setw(14) << "f(b)" << endl;
    cout << string(80, '-') << endl;
    
    int iteration;
    double a_new, b_new;
    
    for (iteration = 1; iteration <= maxIter; iteration++) {
        cout << fixed << setprecision(8);
        cout << left << setw(10) << iteration 
             << setw(14) << a 
             << setw(14) << b 
             << setw(14) << abs(b - a)
             << setw(14) << fa
             << setw(14) << fb << endl;
        
        if (abs(b - a) < epsilon) {
            cout << "\nЗбіжність досягнута за " << iteration << " ітерацій" << endl;
            break;
        }
        
        if (newtonFromA) {
            a_new = a - f(a) / df(a);
            b_new = b - fb * (a - b) / (fa - fb);
        } else {
            a_new = a - fa * (b - a) / (fb - fa);
            b_new = b - fb / df(b);
        }
        
        a = a_new;
        b = b_new;
        fa = f(a);
        fb = f(b);
    }
    
    if (iteration > maxIter) {
        cout << "\nУвага: Досягнуто максимальну кількість ітерацій (" << maxIter << ")" << endl;
    }
    
    double root = (a + b) / 2.0;
    
    cout << "\n" << string(80, '=') << endl;
    cout << "РЕЗУЛЬТАТ:" << endl;
    cout << fixed << setprecision(8);
    cout << "Корінь рівняння: x ≈ " << root << endl;
    cout << "Перевірка: f(" << root << ") = " << f(root) << endl;
    cout << "Точність інтервалу: |b - a| = " << abs(b - a) << endl;
    cout << "Кількість ітерацій: " << iteration << endl;
    cout << string(80, '=') << endl;
}

int main() {
    cout << string(80, '=') << endl;
    cout << "Розв'язання рівняння x^2 * (2 - x) + 0.2 = 0 комбінованим методом" << endl;
    cout << string(80, '=') << endl;
    cout << endl;
    
    double a = 0.88;
    double b = 0.98;
    double epsilon = 0.005;
    
    cout << fixed << setprecision(2);
    cout << "Початковий інтервал: [" << a << ", " << b << "]" << endl;
    cout << "Точність: ε = " << epsilon << endl;
    cout << "f(x) = x^2 * (2 - x) + 0.2 = 2x^2 - x^3 + 0.2" << endl;
    cout << "f'(x) = 4x - 3x^2" << endl;
    cout << "f''(x) = 4 - 6x" << endl;
    cout << endl;
    
    cout << "Перевірка умов:" << endl;
    cout << setprecision(8);
    cout << "f(" << a << ") = " << f(a) << endl;
    cout << "f(" << b << ") = " << f(b) << endl;
    cout << "f(a) * f(b) = " << f(a) * f(b) << " < 0 ✓" << endl;
    cout << "f''(" << a << ") = " << d2f(a) << endl;
    cout << "f''(" << b << ") = " << d2f(b) << endl;
    
    combinedMethod(a, b, epsilon);
    
    return 0;
}
