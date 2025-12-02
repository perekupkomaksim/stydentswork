#include <iostream>
#include <cmath>
#include <stdexcept>
#include <string>
#include <limits>

using namespace std;


class EmptyException {};

class ParameterException {
private:
    double x1, y1, x2, y2;
    string message;
public:
    ParameterException(double x1, double y1, double x2, double y2, const string& msg)
        : x1(x1), y1(y1), x2(x2), y2(y2), message(msg) {}
    
    string what() const {
        return message + " [P1(" + to_string(x1) + "," + to_string(y1) + 
               "), P2(" + to_string(x2) + "," + to_string(y2) + ")]";
    }
};

class InheritedException : public runtime_error {
private:
    double x1, y1, x2, y2;
public:
    InheritedException(double x1, double y1, double x2, double y2, const string& msg)
        : runtime_error(msg), x1(x1), y1(y1), x2(x2), y2(y2) {}
    
    double getX1() const { return x1; }
    double getY1() const { return y1; }
    double getX2() const { return x2; }
    double getY2() const { return y2; }
    
    string getFullMessage() const {
        return string(what()) + " [P1(" + to_string(x1) + "," + to_string(y1) + 
               "), P2(" + to_string(x2) + "," + to_string(y2) + ")]";
    }
};

double calculateDistance1(double x1, double y1, double x2, double y2) {
    
    if (isnan(x1) || isnan(y1) || isnan(x2) || isnan(y2)) {
        throw invalid_argument("Координати не можуть бути NaN");
    }
    if (isinf(x1) || isinf(y1) || isinf(x2) || isinf(y2)) {
        throw overflow_error("Координати не можуть бути безкінечними");
    }
    
    double dx = x1 - x2;
    double dy = y1 - y2;
    double distanceSquared = dx * dx + dy * dy;
    
    if (distanceSquared < 0) {
        throw domain_error("Від'ємне значення під коренем");
    }
    
    return sqrt(distanceSquared);
}

double calculateDistance2(double x1, double y1, double x2, double y2) noexcept {
    try {
        if (isnan(x1) || isnan(y1) || isnan(x2) || isnan(y2)) {
            return -1.0;
        }
        if (isinf(x1) || isinf(y1) || isinf(x2) || isinf(y2)) {
            return -1.0;
        }
        
        double dx = x1 - x2;
        double dy = y1 - y2;
        return sqrt(dx * dx + dy * dy);
    } catch (...) {
        return -1.0;
    }
}

double calculateDistance3(double x1, double y1, double x2, double y2) {
    if (isnan(x1) || isnan(y1) || isnan(x2) || isnan(y2)) {
        throw invalid_argument("Координати містять NaN значення");
    }
    if (isinf(x1) || isinf(y1) || isinf(x2) || isinf(y2)) {
        throw overflow_error("Координати містять безкінечні значення");
    }
    
    double dx = x1 - x2;
    double dy = y1 - y2;
    return sqrt(dx * dx + dy * dy);
}

double calculateDistance4a(double x1, double y1, double x2, double y2) {
    if (isnan(x1) || isnan(y1) || isnan(x2) || isnan(y2)) {
        throw EmptyException();
    }
    if (isinf(x1) || isinf(y1) || isinf(x2) || isinf(y2)) {
        throw EmptyException();
    }
    
    double dx = x1 - x2;
    double dy = y1 - y2;
    return sqrt(dx * dx + dy * dy);
}

double calculateDistance4b(double x1, double y1, double x2, double y2) {
    if (isnan(x1) || isnan(y1) || isnan(x2) || isnan(y2)) {
        throw ParameterException(x1, y1, x2, y2, "Некоректні координати (NaN)");
    }
    if (isinf(x1) || isinf(y1) || isinf(x2) || isinf(y2)) {
        throw ParameterException(x1, y1, x2, y2, "Некоректні координати (Inf)");
    }
    
    double dx = x1 - x2;
    double dy = y1 - y2;
    return sqrt(dx * dx + dy * dy);
}

double calculateDistance4c(double x1, double y1, double x2, double y2) {
    if (isnan(x1) || isnan(y1) || isnan(x2) || isnan(y2)) {
        throw InheritedException(x1, y1, x2, y2, "Координати містять NaN");
    }
    if (isinf(x1) || isinf(y1) || isinf(x2) || isinf(y2)) {
        throw InheritedException(x1, y1, x2, y2, "Координати містять Inf");
    }
    
    double dx = x1 - x2;
    double dy = y1 - y2;
    return sqrt(dx * dx + dy * dy);
}

void testVariant1(double x1, double y1, double x2, double y2) {
    cout << "\n=== ВАРІАНТ 1: Без специфікації виключень ===" << endl;
    try {
        double distance = calculateDistance1(x1, y1, x2, y2);
        cout << "Відстань: " << distance << endl;
    } catch (const invalid_argument& e) {
        cout << "Помилка (invalid_argument): " << e.what() << endl;
    } catch (const overflow_error& e) {
        cout << "Помилка (overflow_error): " << e.what() << endl;
    } catch (const domain_error& e) {
        cout << "Помилка (domain_error): " << e.what() << endl;
    } catch (const exception& e) {
        cout << "Стандартна помилка: " << e.what() << endl;
    } catch (...) {
        cout << "Невідома помилка" << endl;
    }
}

void testVariant2(double x1, double y1, double x2, double y2) {
    cout << "\n=== ВАРІАНТ 2: Зі специфікацією noexcept ===" << endl;
    double distance = calculateDistance2(x1, y1, x2, y2);
    if (distance < 0) {
        cout << "Помилка обчислення (повернуто -1)" << endl;
    } else {
        cout << "Відстань: " << distance << endl;
    }
}

void testVariant3(double x1, double y1, double x2, double y2) {
    cout << "\n=== ВАРІАНТ 3: Зі стандартними виключеннями ===" << endl;
    try {
        double distance = calculateDistance3(x1, y1, x2, y2);
        cout << "Відстань: " << distance << endl;
    } catch (const invalid_argument& e) {
        cout << "Помилка (invalid_argument): " << e.what() << endl;
    } catch (const overflow_error& e) {
        cout << "Помилка (overflow_error): " << e.what() << endl;
    } catch (const exception& e) {
        cout << "Стандартна помилка: " << e.what() << endl;
    }
}

void testVariant4a(double x1, double y1, double x2, double y2) {
    cout << "\n=== ВАРІАНТ 4a: Власне виключення (порожній клас) ===" << endl;
    try {
        double distance = calculateDistance4a(x1, y1, x2, y2);
        cout << "Відстань: " << distance << endl;
    } catch (const EmptyException&) {
        cout << "Помилка (EmptyException): Некоректні параметри" << endl;
    } catch (...) {
        cout << "Невідома помилка" << endl;
    }
}

void testVariant4b(double x1, double y1, double x2, double y2) {
    cout << "\n=== ВАРІАНТ 4b: Власне виключення (з параметрами) ===" << endl;
    try {
        double distance = calculateDistance4b(x1, y1, x2, y2);
        cout << "Відстань: " << distance << endl;
    } catch (const ParameterException& e) {
        cout << "Помилка (ParameterException): " << e.what() << endl;
    } catch (...) {
        cout << "Невідома помилка" << endl;
    }
}

void testVariant4c(double x1, double y1, double x2, double y2) {
    cout << "\n=== ВАРІАНТ 4c: Власне виключення (спадкоємець) ===" << endl;
    try {
        double distance = calculateDistance4c(x1, y1, x2, y2);
        cout << "Відстань: " << distance << endl;
    } catch (const InheritedException& e) {
        cout << "Помилка (InheritedException): " << e.getFullMessage() << endl;
    } catch (const exception& e) {
        cout << "Стандартна помилка: " << e.what() << endl;
    }
}

int main() {
    cout << "====================================================" << endl;
    cout << "ПРОГРАМА ОБЧИСЛЕННЯ ВІДСТАНІ МІЖ ДВОМА ТОЧКАМИ" << endl;
    cout << "З ДЕМОНСТРАЦІЄЮ ОБРОБКИ ВИКЛЮЧЕНЬ" << endl;
    cout << "====================================================" << endl;
    
    cout << "\n\n### ТЕСТ 1: Коректні дані P1(3, 4), P2(0, 0) ###" << endl;
    testVariant1(3, 4, 0, 0);
    testVariant2(3, 4, 0, 0);
    testVariant3(3, 4, 0, 0);
    testVariant4a(3, 4, 0, 0);
    testVariant4b(3, 4, 0, 0);
    testVariant4c(3, 4, 0, 0);
    
    cout << "\n\n### ТЕСТ 2: Некоректні дані (NaN) ###" << endl;
    double nan_val = numeric_limits<double>::quiet_NaN();
    testVariant1(nan_val, 4, 0, 0);
    testVariant2(nan_val, 4, 0, 0);
    testVariant3(nan_val, 4, 0, 0);
    testVariant4a(nan_val, 4, 0, 0);
    testVariant4b(nan_val, 4, 0, 0);
    testVariant4c(nan_val, 4, 0, 0);
    
    cout << "\n\n### ТЕСТ 3: Некоректні дані (Infinity) ###" << endl;
    double inf_val = numeric_limits<double>::infinity();
    testVariant1(inf_val, 4, 0, 0);
    testVariant2(inf_val, 4, 0, 0);
    testVariant3(inf_val, 4, 0, 0);
    testVariant4a(inf_val, 4, 0, 0);
    testVariant4b(inf_val, 4, 0, 0);
    testVariant4c(inf_val, 4, 0, 0);
    
    cout << "\n\n### ТЕСТ 4: P1(1.5, 2.5), P2(4.5, 6.5) ###" << endl;
    testVariant1(1.5, 2.5, 4.5, 6.5);
    testVariant2(1.5, 2.5, 4.5, 6.5);
    testVariant3(1.5, 2.5, 4.5, 6.5);
    testVariant4a(1.5, 2.5, 4.5, 6.5);
    testVariant4b(1.5, 2.5, 4.5, 6.5);
    testVariant4c(1.5, 2.5, 4.5, 6.5);
    
    cout << "\n\n====================================================" << endl;
    cout << "ДЕМОНСТРАЦІЯ ЗАВЕРШЕНА" << endl;
    cout << "====================================================" << endl;
    
    return 0;
}
