package org.example;

public class FileInfo {

    private int id;
    private String name;
    private int size;
    public FileInfo(int id, String name, int size) {
        this.id = id;
        this.name = name;
        this.size = size;
    }
    public int getId() {
        return id;
    }
    public String getName() {
        return name;
    }
    public int getSize() {
        return size;
    }
    @Override
    public String toString() {
        return "FileInfo{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", size=" + size + "MB" +
                '}';
    }
}