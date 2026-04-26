package lab4;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Main {

    public static void main(String[] args) {
        System.out.println("====================================================");
        System.out.println("Лабораторна робота №4 - Generics - Варіант 18");
        System.out.println("====================================================");
        System.out.println();
        demonstrateBox();
        demonstratePair();
        demonstratePrintArray();
        demonstrateFindMax();
        demonstrateNumericStats();
        demonstrateWildcards();
        demonstrateCompileTimeSafety();
        demonstrateTypeErasure();
        System.out.println("====================================================");
        System.out.println("Програма завершена!");
        System.out.println("====================================================");
    }
    private static void demonstrateBox() {
        System.out.println("----------------------------------------------------");
        System.out.println("1) Generic клас Box<T>  |  Тип: Integer (варіант 18)");
        System.out.println("----------------------------------------------------");
        Box<Integer> integerBox = new Box<>();
        integerBox.set(18);
        System.out.println("   Створили Box<Integer> і поклали значення 18");
        System.out.println("   " + integerBox);
        System.out.println("   integerBox.get() = " + integerBox.get());
        integerBox.set(2025);
        System.out.println("   Після setValue(2025): " + integerBox);
        Box<Integer> secondBox = new Box<>(777);
        System.out.println("   Другий Box через конструктор: " + secondBox);
        System.out.println();
        System.out.println("   // Приклад compile-time помилки (ЗАКОМЕНТОВАНО):");
        System.out.println("   // Box<Integer> box = new Box<>();");
        System.out.println("   // box.set(\"рядок\");  <- ПОМИЛКА! String != Integer");
        System.out.println("   // box.set(3.14);     <- ПОМИЛКА! Double != Integer");
        System.out.println();
    }
    private static void demonstratePair() {
        System.out.println("----------------------------------------------------");
        System.out.println("2) Generic клас Pair<K,V>  |  Типи: Double, Long (варіант 18)");
        System.out.println("----------------------------------------------------");
        Pair<Double, Long> pair = new Pair<>(3.14, 1000000L);
        System.out.println("   Створили Pair<Double, Long>");
        System.out.println("   " + pair);
        System.out.println("   pair.getKey()   = " + pair.getKey()   + "  (це Double)");
        System.out.println("   pair.getValue() = " + pair.getValue() + "  (це Long)");
        Pair<Double, Long> pair2 = new Pair<>(2.718, 999L);
        System.out.println("   Другий Pair: " + pair2);
        System.out.println();
        System.out.println("   // Приклади compile-time помилок (ЗАКОМЕНТОВАНО):");
        System.out.println("   // new Pair<Double, Long>(\"рядок\", 10L);  <- ПОМИЛКА! String != Double");
        System.out.println("   // new Pair<Double, Long>(1.0, \"текст\");   <- ПОМИЛКА! String != Long");
        System.out.println("   // Компілятор чітко слідкує щоб типи співпадали!");
        System.out.println();
    }
    private static void demonstratePrintArray() {
        System.out.println("----------------------------------------------------");
        System.out.println("3) Generic метод printArray(T[])  |  Тип: Integer[] (варіант 18)");
        System.out.println("----------------------------------------------------");
        Integer[] intArray = {10, 20, 30, 40, 50};
        System.out.println("   Викликаємо printArray з Integer[]:");
        Utils.printArray(intArray, "   Integer масив:");
        System.out.println();
        System.out.println("   Той самий метод з String[] (generic - працює для будь-якого типу):");
        String[] strArray = {"Java", "Generics", "Варіант", "18"};
        Utils.printArray(strArray, "   String масив:");
        System.out.println();
        System.out.println("   Пояснення: <T> перед void - це оголошення generic методу.");
        System.out.println("   Компілятор автоматично визначає тип T при виклику.");
        System.out.println("   Не потрібно робити приведення типів (casting)!");
        System.out.println();
    }
    private static void demonstrateFindMax() {
        System.out.println("----------------------------------------------------");
        System.out.println("4) Generic метод findMax з обмеженням <T extends Comparable>");
        System.out.println("----------------------------------------------------");
        List<Integer> integerList = Arrays.asList(5, 2, 8, 1, 9, 3);
        Integer maxInt = Utils.findMax(integerList);
        System.out.println("   Список Integer: " + integerList);
        System.out.println("   Максимум: " + maxInt);
        List<Double> doubleList = Arrays.asList(1.5, 3.7, 2.1, 4.9, 0.3);
        Double maxDouble = Utils.findMax(doubleList);
        System.out.println("   Список Double:  " + doubleList);
        System.out.println("   Максимум: " + maxDouble);
        System.out.println();
        System.out.println("   Пояснення: <T extends Comparable<? super T>> дозволяє");
        System.out.println("   використовувати compareTo() для порівняння елементів.");
        System.out.println();
    }
    private static void demonstrateNumericStats() {
        System.out.println("----------------------------------------------------");
        System.out.println("5) Bounded type NumericStats<T extends Number>  |  Тип: Double (варіант 18)");
        System.out.println("----------------------------------------------------");
        List<Double> doubleNumbers = Arrays.asList(10.5, 2.0, 8.3, 4.7, 15.0, 3.5);
        NumericStats<Double> stats = new NumericStats<>(doubleNumbers);
        System.out.println("   Числа: " + doubleNumbers);
        System.out.println("   Кількість: " + stats.getCount());
        System.out.println("   Сума:      " + stats.calculateSum());
        System.out.println("   Середнє:   " + stats.calculateAverage());
        System.out.println("   Мінімум:   " + stats.findMin());
        System.out.println("   Максимум:  " + stats.findMax());
        System.out.println();
        System.out.println("   Пояснення: 'T extends Number' дозволяє викликати");
        System.out.println("   doubleValue() бо цей метод є у класі Number.");
        System.out.println("   Без bounded type -> doubleValue() недоступний!");
        System.out.println();
        System.out.println("   // Compile-time помилка (ЗАКОМЕНТОВАНО):");
        System.out.println("   // NumericStats<String> s = new NumericStats<>(...); <- ПОМИЛКА!");
        System.out.println("   // String не є підкласом Number!");
        System.out.println();
    }
    private static void demonstrateWildcards() {
        System.out.println("----------------------------------------------------");
        System.out.println("6) Wildcard типи  |  Опорний тип: Integer (варіант 18)");
        System.out.println("----------------------------------------------------");
        System.out.println("   6.1) List<?> - unbounded wildcard:");
        List<Integer> someIntegers = Arrays.asList(1, 2, 3, 4, 5);
        WildcardDemo.printUnknownList(someIntegers);
        System.out.println();
        System.out.println("   6.2) List<? extends Number> - upper bounded wildcard:");
        List<Integer> intList = Arrays.asList(10, 20, 30);
        WildcardDemo.printNumbersList(intList);
        System.out.println();
        System.out.println("   6.3) List<? super Integer> - lower bounded wildcard:");
        List<Number> numberList = new ArrayList<>();
        WildcardDemo.addIntegersToList(numberList);
        System.out.println();
    }
    private static void demonstrateCompileTimeSafety() {
        System.out.println("----------------------------------------------------");
        System.out.println("7) Compile-time type safety - помилки виявляються ПРИ КОМПІЛЯЦІЇ");
        System.out.println("----------------------------------------------------");
        Box<Integer> box = new Box<>();
        box.set(42);
        System.out.println("   Box<Integer> box -> box.set(42) -> OK: " + box);
        Pair<Double, Long> pair = new Pair<>(1.23, 456L);
        System.out.println("   Pair<Double,Long> -> OK: " + pair);
        List<Integer> intOnlyList = new ArrayList<>();
        intOnlyList.add(1);
        intOnlyList.add(2);
        intOnlyList.add(3);
        System.out.println("   List<Integer> -> OK: " + intOnlyList);
        System.out.println();
        System.out.println("   Приклади ЗАКОМЕНТОВАНИХ помилок компіляції:");
        System.out.println("   // box.set(\"текст\");           <- ПОМИЛКА: String != Integer");
        System.out.println("   // box.set(3.14);              <- ПОМИЛКА: Double != Integer");
        System.out.println("   // intOnlyList.add(\"слово\");   <- ПОМИЛКА: String != Integer");
        System.out.println("   // intOnlyList.add(1.5);       <- ПОМИЛКА: Double != Integer");
        System.out.println("   // new Pair<Double,Long>(1L, 2.0) <- ПОМИЛКА: типи переплутані");
        System.out.println();
        System.out.println("   Generics виявляють ці помилки ДО запуску програми!");
        System.out.println("   Без generics помилка виникла б під час виконання (ClassCastException).");
        System.out.println();
    }
    private static void demonstrateTypeErasure() {
        System.out.println("----------------------------------------------------");
        System.out.println("8) Type Erasure - механізм стирання типів");
        System.out.println("----------------------------------------------------");
        ErasureDemo.run();
        System.out.println();
    }
}