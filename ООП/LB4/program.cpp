#include <iostream>
#include <iomanip>

class Longlong {
private:
    long high;
    unsigned long low;

public:
    Longlong() : high(0), low(0) {}
    
    Longlong(long h, unsigned long l) : high(h), low(l) {}
    
    Longlong(long long value) {
        high = (value >> 32) & 0xFFFFFFFF;
        low = value & 0xFFFFFFFF;
    }

    long getHigh() const { return high; }
    unsigned long getLow() const { return low; }

    Longlong operator+(const Longlong& other) const {
        Longlong result;
        result.low = this->low + other.low;
        result.high = this->high + other.high;
        
        if (result.low < this->low) {
            result.high++;
        }
        
        return result;
    }

    Longlong operator-(const Longlong& other) const {
        Longlong result;
        result.low = this->low - other.low;
        result.high = this->high - other.high;
        
        if (this->low < other.low) {
            result.high--;
        }
        
        return result;
    }

    Longlong operator*(const Longlong& other) const {
        long long val1 = ((long long)this->high << 32) | this->low;
        long long val2 = ((long long)other.high << 32) | other.low;
        long long result_val = val1 * val2;
        
        return Longlong(result_val);
    }

    Longlong operator/(const Longlong& other) const {
        if (other.high == 0 && other.low == 0) {
            throw std::runtime_error("Ділення на нуль!");
        }
        
        long long val1 = ((long long)this->high << 32) | this->low;
        long long val2 = ((long long)other.high << 32) | other.low;
        long long result_val = val1 / val2;
        
        return Longlong(result_val);
    }

    Longlong operator%(const Longlong& other) const {
        if (other.high == 0 && other.low == 0) {
            throw std::runtime_error("Ділення на нуль!");
        }
        
        long long val1 = ((long long)this->high << 32) | this->low;
        long long val2 = ((long long)other.high << 32) | other.low;
        long long result_val = val1 % val2;
        
        return Longlong(result_val);
    }

    Longlong operator-() const {
        Longlong result;
        result.low = ~this->low + 1;
        result.high = ~this->high;
        
        if (result.low == 0) {
            result.high++;
        }
        
        return result;
    }

    Longlong& operator++() {
        low++;
        if (low == 0) {
            high++;
        }
        return *this;
    }

    Longlong operator++(int) {
        Longlong temp = *this;
        ++(*this);
        return temp;
    }

    Longlong& operator--() {
        if (low == 0) {
            high--;
        }
        low--;
        return *this;
    }

    Longlong operator--(int) {
        Longlong temp = *this;
        --(*this);
        return temp;
    }

    bool operator==(const Longlong& other) const {
        return (this->high == other.high) && (this->low == other.low);
    }

    bool operator!=(const Longlong& other) const {
        return !(*this == other);
    }

    bool operator<(const Longlong& other) const {
        if (this->high != other.high) {
            return this->high < other.high;
        }
        return this->low < other.low;
    }

    bool operator>(const Longlong& other) const {
        return other < *this;
    }

    bool operator<=(const Longlong& other) const {
        return !(other < *this);
    }

    bool operator>=(const Longlong& other) const {
        return !(*this < other);
    }

    friend std::ostream& operator<<(std::ostream& os, const Longlong& ll) {
        long long value = ((long long)ll.high << 32) | ll.low;
        os << value;
        os << " [Високий: 0x" << std::hex << ll.high 
           << ", Низький: 0x" << ll.low << std::dec << "]";
        return os;
    }

    friend std::istream& operator>>(std::istream& is, Longlong& ll) {
        long long value;
        is >> value;
        ll.high = (value >> 32) & 0xFFFFFFFF;
        ll.low = value & 0xFFFFFFFF;
        return is;
    }
};

int main() {
    std::cout << "=== Тестування класу Longlong ===" << std::endl << std::endl;

    Longlong a(0, 100);
    Longlong b(0, 50);
    Longlong c(1, 4294967295UL);

    std::cout << "a = " << a << std::endl;
    std::cout << "b = " << b << std::endl;
    std::cout << "c = " << c << std::endl << std::endl;

    std::cout << "--- Арифметичні операції ---" << std::endl;
    Longlong sum = a + b;
    std::cout << "a + b = " << sum << std::endl;

    Longlong diff = a - b;
    std::cout << "a - b = " << diff << std::endl;

    Longlong prod = a * b;
    std::cout << "a * b = " << prod << std::endl;

    Longlong quot = a / b;
    std::cout << "a / b = " << quot << std::endl;

    Longlong mod = a % b;
    std::cout << "a % b = " << mod << std::endl << std::endl;

    std::cout << "--- Унарні операції ---" << std::endl;
    Longlong neg = -a;
    std::cout << "-a = " << neg << std::endl;

    Longlong d = a;
    std::cout << "d = a = " << d << std::endl;
    std::cout << "++d = " << ++d << std::endl;
    std::cout << "d++ = " << d++ << std::endl;
    std::cout << "d = " << d << std::endl << std::endl;

    std::cout << "--- Операції порівняння ---" << std::endl;
    std::cout << "a == b: " << (a == b ? "Так" : "Ні") << std::endl;
    std::cout << "a != b: " << (a != b ? "Так" : "Ні") << std::endl;
    std::cout << "a < b: " << (a < b ? "Так" : "Ні") << std::endl;
    std::cout << "a > b: " << (a > b ? "Так" : "Ні") << std::endl;
    std::cout << "a <= b: " << (a <= b ? "Так" : "Ні") << std::endl;
    std::cout << "a >= b: " << (a >= b ? "Так" : "Ні") << std::endl << std::endl;

    std::cout << "--- Тест з переповненням ---" << std::endl;
    Longlong e(0, 4294967295UL);
    std::cout << "e = " << e << std::endl;
    Longlong f = e + Longlong(0, 1);
    std::cout << "e + 1 = " << f << std::endl;

    return 0;
}
