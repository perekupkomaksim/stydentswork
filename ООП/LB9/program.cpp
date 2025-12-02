#include <iostream>
#include <stdexcept>

using namespace std;

class LongLong {
private:
    long high;
    unsigned long low;

public:
    LongLong(long h = 0, unsigned long l = 0)
        : high(h), low(l) {}

    long getHigh() const { return high; }
    unsigned long getLow() const { return low; }

    __int128 to128() const {
        __int128 x = (__int128)high << 64;
        x |= low;
        return x;
    }

    static LongLong from128(__int128 x) {
        long h = (long)(x >> 64);
        unsigned long l = (unsigned long)x;
        return LongLong(h, l);
    }

    LongLong operator+(const LongLong& other) const {
        return from128(to128() + other.to128());
    }

    LongLong operator-(const LongLong& other) const {
        return from128(to128() - other.to128());
    }

    LongLong operator*(const LongLong& other) const {
        return from128(to128() * other.to128());
    }

    LongLong operator/(const LongLong& other) const {
        if (other.to128() == 0)
            throw runtime_error("Division by zero");
        return from128(to128() / other.to128());
    }

    bool operator==(const LongLong& other) const { return to128() == other.to128(); }
    bool operator!=(const LongLong& other) const { return to128() != other.to128(); }
    bool operator<(const LongLong& other)  const { return to128() <  other.to128(); }
    bool operator>(const LongLong& other)  const { return to128() >  other.to128(); }
    bool operator<=(const LongLong& other) const { return to128() <= other.to128(); }
    bool operator>=(const LongLong& other) const { return to128() >= other.to128(); }

    friend ostream& operator<<(ostream& os, const LongLong& v) {
        __int128 x = v.to128();
        if (x < 0) { os << "-"; x = -x; }
        unsigned long long low = (unsigned long long)x;
        __int128 high128 = x >> 64;
        unsigned long long high = (unsigned long long)high128;

        if (high == 0)
            os << low;
        else
            os << high << " * 2^64 + " << low;

        return os;
    }
};

class Figure {
public:
    virtual LongLong area() const = 0;
    virtual void print() const = 0;
    virtual ~Figure() {}
};

class Rectangle : public Figure {
private:
    LongLong a;
    LongLong b;

public:
    Rectangle(LongLong A, LongLong B) : a(A), b(B) {}

    LongLong area() const override {
        return a * b;
    }

    void print() const override {
        cout << "Прямокутник: A=" << a << ", B=" << b << endl;
    }
};

int main() {
    LongLong x(0, 10), y(0, 20);

    LongLong z = x + y;
    cout << "10 + 20 = " << z << endl;

    Rectangle R(LongLong(0, 5), LongLong(0, 7));
    R.print();
    cout << "Площа = " << R.area() << endl;

    return 0;
}

