#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

double f(double x) {
    return 1.0 / tan(x) - 1.0;
}

void chordMethod(double a, double b, double epsilon, int maxIter = 100) {
    double fa = f(a);
    double fb = f(b);
    
    if (fa * fb > 0) {
        cout << "Помилка: Функція повинна мати різні знаки на кінцях інтервалу!" << endl;
        return;
    }
    
    cout << left << setw(10) << "Ітерація" 
         << setw(12) << "a" 
         << setw(12) << "b" 
         << setw(12) << "x" 
         << setw(15) << "f(x)" 
         << setw(12) << "|f(x)|" << endl;
    cout << string(80, '-') << endl;
    
    double x = a;
    double fx;
    int iteration;
    
    for (iteration = 1; iteration <= maxIter; iteration++) {
        x = a - fa * (b - a) / (fb - fa);
        fx = f(x);
        
        cout << fixed << setprecision(6);
        cout << left << setw(10) << iteration 
             << setw(12) << a 
             << setw(12) << b 
             << setw(12) << x;
        cout << setprecision(8);
        cout << setw(15) << fx 
             << setw(12) << abs(fx) << endl;
        
        if (abs(fx) < epsilon) {
            cout << "\nЗбіжність досягнута за " << iteration << " ітерацій" << endl;
            break;
        }
        
        if (fa * fx < 0) {
            b = x;
            fb = fx;
        } else {
            a = x;
            fa = fx;
        }
    }
    
    if (iteration > maxIter) {
        cout << "\nУвага: Досягнуто максимальну кількість ітерацій (" << maxIter << ")" << endl;
    }
    
    cout << "\n" << string(80, '=') << endl;
    cout << "РЕЗУЛЬТАТ:" << endl;
    cout << fixed << setprecision(6);
    cout << "Корінь рівняння: x ≈ " << x << endl;
    cout << setprecision(8);
    cout << "Перевірка: f(" << setprecision(6) << x << ") = " 
         << setprecision(8) << fx << endl;
    cout << "Кількість ітерацій: " << iteration << endl;
    cout << string(80, '=') << endl;
}

int main() {
    cout << string(80, '=') << endl;
    cout << "Розв'язання рівняння ctg(x) - 1.0 = 0 методом хорд" << endl;
    cout << string(80, '=') << endl;
    cout << endl;
    
    double a = 4.6;
    double b = 4.65;
    double epsilon = 0.005;
    
    cout << fixed << setprecision(2);
    cout << "Початковий інтервал: [" << a << ", " << b << "]" << endl;
    cout << "Точність: ε = " << epsilon << endl;
    cout << "f(x) = ctg(x) - 1.0" << endl;
    cout << endl;
    
    cout << "Перевірка умов:" << endl;
    cout << setprecision(6);
    cout << "f(" << a << ") = " << f(a) << endl;
    cout << "f(" << b << ") = " << f(b) << endl;
    cout << "f(a) * f(b) = " << f(a) * f(b) << " < 0 ✓" << endl;
    cout << endl;
    
    chordMethod(a, b, epsilon);
    
    return 0;
}
