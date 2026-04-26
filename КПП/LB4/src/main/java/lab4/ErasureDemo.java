package lab4;

import java.util.ArrayList;
import java.util.List;

public final class ErasureDemo {
    private ErasureDemo() {}
    public static void run() {
        List<String> stringList = new ArrayList<>();
        stringList.add("Привіт");
        stringList.add("Generics");
        List<Integer> integerList = new ArrayList<>();
        integerList.add(18);
        integerList.add(2025);
        System.out.println("   stringList.getClass()  = " + stringList.getClass().getName());
        System.out.println("   integerList.getClass() = " + integerList.getClass().getName());
        boolean areSameClass = stringList.getClass() == integerList.getClass();
        System.out.println("   stringList.getClass() == integerList.getClass() ? " + areSameClass);
        System.out.println();
        System.out.println("   Пояснення:");
        System.out.println("   Компілятор перетворює List<String> і List<Integer>");
        System.out.println("   на просто List (без параметра типу) у байткоді.");
        System.out.println("   Тому під час виконання вони виглядають однаково.");
        System.out.println();
        System.out.println("   Через це не можна написати:");
        System.out.println("   if (list instanceof List<String>) { }  // НЕ КОМПІЛЮЄТЬСЯ!");
        System.out.println("   Можна тільки: if (list instanceof List) { }");
        List<?> someList = new ArrayList<String>();
        if (someList instanceof List) {
            System.out.println("   someList instanceof List -> true (без параметра типу - ОК)");
        }
    }
}