using System;

public class MyType {

  static int counter = 0;

  int data;

  string text;

  int Operation(int a)
  {
    return data + a + 3;
  }

  class X
  {
    public int x;
    public int y;
  }

  int Rate {
    get { return data + 3; }
    set { data = value - 3; }
  }
}
