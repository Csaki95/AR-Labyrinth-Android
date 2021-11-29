# Golyóterelő ügyességi labirintus játék kiterjesztett valóságban
szakdolgozat - SZTE TTIK Csáki Gergő

## Feladat megfogalmazása
A feladat egy kézi labirintus játék fejlesztése kiterjesztett valóságban Android készülékekre. A pálya, és golyó testek lemodellezése, illetve az eszköz hátlapi kamerájával kép beazonosítása, majd labirintus rávetítése, és fizikai szimulációja a mozgásának megfelelően.

## Megoldási mód
Prototípus létrehozását követően a kívánt kiterjesztett valóság funkcionalitást kínáló csomagok tesztelése, majd a felhasználásnak megfelelővel játék fejlesztése az elsajátított szoftverfejlesztési, és számítógépes grafikai ismeretek segítségével. Emellett a négy pályához felhasznált labirintusok, és az azokban terelt golyók modellezése.

## Telepítés
 A játék használatához szükséges egy [ARCore](https://developers.google.com/ar/discover/supported-devices) kompatibilis eszköz, illetve engedélyezni kell az ismeretlen forrásból származó alkalmazások telepítését.
 
 Az alkalmazás elérhető: 
 * [.apk Letöltés/Download](https://github.com/Csaki95/AR-Labirinth-2019-Android/raw/master/Builds/AR%20Labyrinth.apk)
 * [Play Store link](https://play.google.com/store/apps/details?id=com.AteYourGame.ARLabyrinth)
 
 ## Fejlesztés
 A játék Unity 2020.1.10f verzióban készül ARCore 1.20.0-ra építve.
 
 Jelenlegi teszt eszközök:
 * Samsung Galaxy A71
 * Xiaomi Redmi Note 8
 
 ## Targetek
 
 Az elsődleges target kép a következő tengerpart fotó. A névjegykártya target része is erre lesz építve letöltéshez kattintson a képre.
 
 <img src="Assets/Target/nature-4785780_1920.jpg" width="250">
 
 Továbbra is használható viszont a referencia kép, amely valamivel jobban működik gyenge fényforrásoknál is.
 
 <img src="Assets/Target/augmented-images-earth.jpg" width="250">
 
