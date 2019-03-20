using System;
using MagicCreatures;

class Program
{
    static void Main()
    {
        Elf elf = new Elf();
        elf.ElfInfo();

        Gnome gnome = new Gnome();
        gnome.GnomeInfo();

        Daemon daemon = new Daemon();
        daemon.DaemonInfo();

        Console.ReadLine();
    }
}