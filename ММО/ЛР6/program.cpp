#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;

double f(double x)
{
    return sin(x + M_PI / 3.0) * sin(x + M_PI / 3.0) - x * x / 4.0;
}

double f_derivative(double x)
{
    return 2.0 * sin(x + M_PI / 3.0) * cos(x + M_PI / 3.0) - x / 2.0;
}

int main()
{
    setlocale(LC_ALL, "Ukrainian");
    
    double a = 1.0;
    double b = 2.0;
    const double eps = 0.02;
    
    cout << "=== Розв'язання рівняння sin²(x + π/3) - (x/2)² = 0 ===" << endl;
    cout << "Відрізок: [" << a << "; " << b << "]" << endl;
    cout << "Точність: " << eps << endl << endl;
    
    double z = a;
    double x = a;
    int n = 0;
    
    cout << fixed << setprecision(6);
    cout << "n\tx (Ньютон)\tz (Хорд)\t|x-z|" << endl;
    cout << "---------------------------------------------------" << endl;
    
    do {
        double x_new = x - f(x) / f_derivative(x);
        
        double z_new = z - (f(z) * (b - z)) / (f(b) - f(z));
        
        double dx = fabs(x_new - z_new);
        
        cout << n << "\t" << x_new << "\t" << z_new << "\t" << dx << endl;
        
        x = x_new;
        z = z_new;
        n++;
        
        if (dx <= eps) {
            cout << "\nТочність досягнуто!" << endl;
            break;
        }
        
    } while (n < 100);
    
    double result = (x + z) / 2.0;
    
    cout << "\n=== РЕЗУЛЬТАТ ===" << endl;
    cout << "Корінь рівняння: x ≈ " << result << endl;
    cout << "Перевірка: f(" << result << ") = " << f(result) << endl;
    cout << "Кількість ітерацій: " << n << endl;
    
    return 0;
}
