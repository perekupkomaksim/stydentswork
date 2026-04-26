package lab4;

import java.util.ArrayList;
import java.util.List;

public final class WildcardDemo {
    private WildcardDemo() {}
    public static void printUnknownList(List<?> list) {
        System.out.println("   Unbounded wildcard List<?> - читаємо як Object:");
        for (Object element : list) {
            System.out.println("      " + element);
        }
    }
    public static void printNumbersList(List<? extends Number> list) {
        System.out.println("   Upper bounded wildcard List<? extends Number> - лише читання:");
        for (Number number : list) {
            System.out.println("      " + number
                    + " -> doubleValue = " + number.doubleValue()
                    + ", intValue = " + number.intValue());
        }
    }
    public static void addIntegersToList(List<? super Integer> list) {
        System.out.println("   Lower bounded wildcard List<? super Integer> - можна додавати Integer:");
        list.add(100);
        list.add(200);
        list.add(300);
        System.out.println("   Додали 3 елементи. Вміст списку (читаємо як Object):");
        for (Object element : list) {
            System.out.println("      " + element);
        }
    }
}