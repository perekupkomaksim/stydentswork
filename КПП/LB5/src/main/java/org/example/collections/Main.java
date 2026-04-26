package org.example.collections;

import java.util.*;

public class Main {

    public static void main(String[] args) {

        System.out.println("===== LAB 5 : JAVA COLLECTIONS (Variant 31) =====");

        // =============================================
        // 1. Генерація 50 студентів
        // =============================================
        int numberOfStudents = 50;
        List<Student> students = StudentGenerator.generateStudents(numberOfStudents);

        System.out.println("\n--- Generated students ---");
        for (Student s : students) {
            System.out.println(s);
        }

        // =============================================
        // 2. Сортування через Comparable (за grade)
        // =============================================
        System.out.println("\n--- Sorting by grade (Comparable) ---");
        Collections.sort(students);
        for (Student s : students) {
            System.out.println(s);
        }

        // =============================================
        // 3. Сортування через Comparator (за id)
        // =============================================
        System.out.println("\n--- Sorting by id (Comparator) ---");
        students.sort(new StudentIdComparator());
        for (Student s : students) {
            System.out.println(s);
        }

        // =============================================
        // 4. HashSet — перевірка унікальності
        // =============================================
        System.out.println("\n--- Testing HashSet ---");
        Set<Student> studentSet = new HashSet<>();
        studentSet.addAll(students);

        // Спроба додати дублікат (той самий id=1)
        Student duplicate = new Student(1, "Duplicate", 99);
        boolean added = studentSet.add(duplicate);
        System.out.println("Trying to add duplicate (id=1): " + (added ? "added" : "rejected"));
        System.out.println("HashSet size = " + studentSet.size());

        for (Student s : studentSet) {
            System.out.println(s);
        }

        // =============================================
        // 5. HashMap — зберігання за ключем id
        // =============================================
        System.out.println("\n--- Testing HashMap ---");
        Map<Integer, Student> studentMap = new HashMap<>();
        for (Student s : students) {
            studentMap.put(s.getId(), s);
        }
        System.out.println("HashMap size = " + studentMap.size());

        // Пошук елемента
        int searchId = 10;
        System.out.println("\nSearching student with id = " + searchId);
        Student found = studentMap.get(searchId);
        System.out.println("Result: " + found);

        // =============================================
        // 6. Експеримент продуктивності HashMap
        // =============================================
        System.out.println("\n--- Performance test: normal hashCode() ---");
        performanceTest(50);
        performanceTest(1000);
        performanceTest(10000);

        // =============================================
        // 7. Експеримент з колізіями (деградований hashCode)
        // =============================================
        System.out.println("\n--- Collision experiment: hashCode() = 1 ---");
        collisionTest(50);
        collisionTest(1000);
        collisionTest(10000);

        // =============================================
        // 8. Порівняльна таблиця
        // =============================================
        System.out.println("\n--- Summary ---");
        System.out.println("Normal hashCode:  O(1) — час майже не змінюється");
        System.out.println("Bad hashCode:     O(n)/O(log n) — час різко зростає");
    }

    // ====================================================
    // Метод тестування продуктивності (нормальний hashCode)
    // ====================================================
    private static void performanceTest(int size) {
        Map<Integer, Student> map = new HashMap<>();
        List<Student> students = StudentGenerator.generateStudents(size);

        for (Student s : students) {
            map.put(s.getId(), s);
        }

        // Прогрів JVM
        for (int i = 0; i < 100; i++) {
            map.get(size / 2);
        }

        // Вимірювання
        long start = System.nanoTime();
        map.get(size / 2);
        long end = System.nanoTime();

        System.out.println("Size = " + size +
                " | search time = " + (end - start) + " ns");
    }

    // ====================================================
    // Метод тестування з деградованим hashCode (колізії)
    // ====================================================
    private static void collisionTest(int size) {
        Map<Integer, BadStudent> map = new HashMap<>();
        List<BadStudent> students = StudentGenerator.generateBadStudents(size);

        for (BadStudent s : students) {
            map.put(s.getId(), s);
        }

        // Прогрів JVM
        for (int i = 0; i < 100; i++) {
            map.get(size / 2);
        }

        // Вимірювання
        long start = System.nanoTime();
        map.get(size / 2);
        long end = System.nanoTime();

        System.out.println("Collision test size = " + size +
                " | search time = " + (end - start) + " ns");
    }
}