package lab4;

import java.util.List;

public final class Utils {
    private Utils() {}
    public static <T> void printArray(T[] array, String title) {
        System.out.println(title);
        for (T element : array) {
            System.out.println("   " + element);
        }
    }
    public static <T extends Comparable<? super T>> T findMax(List<T> list) {
        if (list == null || list.isEmpty()) {
            throw new IllegalArgumentException("Список порожній! Неможливо знайти максимум.");
        }
        T maxElement = list.get(0);
        for (T currentElement : list) {
            if (currentElement.compareTo(maxElement) > 0) {
                maxElement = currentElement;
            }
        }
        return maxElement;
    }
}