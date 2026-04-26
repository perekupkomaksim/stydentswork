package org.example;

import java.util.ArrayList;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.function.Predicate;
import java.util.function.Supplier;

public class Main {

    public static void main(String[] args) {
        ArrayList<FileInfo> files = new ArrayList<FileInfo>();
        files.add(new FileInfo(1, "report.pdf", 120));
        files.add(new FileInfo(2, "photo.jpg", 85));
        files.add(new FileInfo(3, "archive.zip", 300));
        files.add(new FileInfo(4, "notes.txt", 45));
        files.add(new FileInfo(5, "video.mp4", 512));
        files.add(new FileInfo(6, "config.xml", 12));
        System.out.println("=== 1. ПОЧАТКОВИЙ СПИСОК ===");
        for (int i = 0; i < files.size(); i++) {
            System.out.println(files.get(i));
        }
        System.out.println("\n=== 2. АНОНІМНИЙ КЛАС ===");
        Printer<FileInfo> printerAnon = new Printer<FileInfo>() {
            @Override
            public void print(FileInfo f) {
                System.out.println("Анонімний клас -> " + f.getName() + " (" + f.getSize() + "MB)");
            }
        };
        for (int i = 0; i < files.size(); i++) {
            printerAnon.print(files.get(i));
        }
        System.out.println("\n=== 3. LAMBDA-ВИРАЗ (те саме але коротше) ===");
        Printer<FileInfo> printerLambda = f -> System.out.println("Lambda -> " + f.getName() + " (" + f.getSize() + "MB)");
        files.forEach(f -> printerLambda.print(f));
        System.out.println("\n=== 4. СОРТУВАННЯ ЗА РОЗМІРОМ ===");
        files.sort((a, b) -> Integer.compare(a.getSize(), b.getSize()));
        files.forEach(f -> System.out.println(f));
        System.out.println("\n=== 5. PREDICATE - файли розміром >= 100MB ===");
        Predicate<FileInfo> isBigFile = f -> f.getSize() >= 100;
        ArrayList<FileInfo> bigFiles = new ArrayList<FileInfo>();
        for (FileInfo f : files) {
            if (isBigFile.test(f)) {
                bigFiles.add(f);
            }
        }
        System.out.println("Великі файли:");
        bigFiles.forEach(f -> System.out.println(f));
        System.out.println("\n=== 6. REMOVEIF - видаляю файли < 100MB ===");
        ArrayList<FileInfo> filteredList = new ArrayList<FileInfo>(files);
        filteredList.removeIf(f -> f.getSize() < 100);
        System.out.println("Після видалення:");
        filteredList.forEach(f -> System.out.println(f));
        System.out.println("\n=== 7. FUNCTION - отримую розмір файлу ===");
        Function<FileInfo, Integer> getSize = f -> f.getSize();
        System.out.println("Розміри великих файлів:");
        for (FileInfo f : filteredList) {
            Integer size = getSize.apply(f);
            System.out.println(f.getName() + " -> " + size + "MB");
        }
        System.out.println("\n=== 8. CONSUMER - виводжу назву файлу ===");
        Consumer<FileInfo> showName = f -> System.out.println("Назва файлу: " + f.getName());
        filteredList.forEach(f -> showName.accept(f));
        System.out.println("\n=== 9. SUPPLIER - генерую файл за замовчуванням ===");
        Supplier<FileInfo> defaultFile = () -> new FileInfo(0, "default.txt", 10);
        FileInfo newFile = defaultFile.get();
        System.out.println("Файл за замовчуванням: " + newFile);
        System.out.println("\n=== 10. METHOD REFERENCES ===");
        System.out.println("Вивід через method reference:");
        Supplier<ArrayList<FileInfo>> listFactory = ArrayList::new;
        ArrayList<FileInfo> newList = listFactory.get();
        System.out.println("Новий порожній список: " + newList);
    }
}