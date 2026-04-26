package lab4;

import java.util.List;

public class NumericStats<T extends Number> {
    private final List<T> numbers;
    public NumericStats(List<T> numbers) {
        this.numbers = numbers;
    }
    public double calculateSum() {
        double sum = 0.0;
        for (T number : numbers) {
            sum += number.doubleValue();
        }
        return sum;
    }
    public double calculateAverage() {
        if (numbers.isEmpty()) {
            return 0.0;
        }
        return calculateSum() / numbers.size();
    }
    public double findMin() {
        if (numbers.isEmpty()) {
            throw new IllegalStateException("Список порожній!");
        }
        double min = numbers.get(0).doubleValue();

        for (T number : numbers) {
            double currentValue = number.doubleValue();
            if (currentValue < min) {
                min = currentValue;
            }
        }
        return min;
    }
    public double findMax() {
        if (numbers.isEmpty()) {
            throw new IllegalStateException("Список порожній!");
        }
        double max = numbers.get(0).doubleValue();

        for (T number : numbers) {
            double currentValue = number.doubleValue();
            if (currentValue > max) {
                max = currentValue;
            }
        }
        return max;
    }
    public int getCount() {
        return numbers.size();
    }
}