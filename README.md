# Unity Forging Minigame  

### Opis projektu  
To jest testowy projekt rekrutacyjny, w którym stworzyłem minigrę o wykuwaniu przedmiotów.  
Gracz zarządza ekwipunkiem, przetwarza surowce w maszynach i wykonuje questy, aby odblokować nowe funkcje.  

## Jak uruchomić projekt?  
1. Proszę sklonować repozytorium git clone https://github.com/kynesss/AncientForge
2. Proszę otworzyć pliki projektu w wybranym edytorze Unity (najlepiej Unity 6 - ja korzystałem z Unity 6000.0.35f1)

## Stukura projektu
  1. Inventory System
        -Inventory.cs → Zarządza ekwipunkiem gracza.
        -InventorySlotUI.cs → Obsługuje interfejs przeciągania przedmiotów (Drag/Drop).
        -InventoryUI.cs → Wyświetla ekwipunek gracza.
     
  3. Machine System
        -Machine.cs → Główna logika przetwarzania przedmiotów w maszynach.
        -MachineUI.cs → Otwiera panel danej maszyny i obsługuje crafting.
     
  4. Quest System
        -QuestManager.cs → Zarządza aktywnymi questami
        -QuestData.cs → Skryptowalne obiekty przechowujące informacje o questach.
        -Quest.cs → Przechowuje postęp questa

## Decyzje techniczne
  1. System przepisów maszyn
        -Maszyny przechowują przepisy jako listę MachineRecipe, co pozwala na łatwe dodawanie nowych przedmiotów.

  2. System questów jako ScriptableObject
        -Questy są oddzielone od logiki – przechowują tylko dane i są łatwe do edytowania w Unity.

  3. System wytwarzania przedmiotów  
       -Zainspirowałem się systemem craftingowym z Minecrafta, gdzie gracz widzi, jakie przedmioty są wymagane do stworzenia nowego przedmiotu.
       -Uznałem, że UX-owo fajnym rozwiązaniem jest możliwość przełączania się między różnymi przepisami w danej maszynie, zamiast wymuszać osobne interakcje dla każdego z nich.

  4. System Drag and Drop  
       -Zdecydowałem się na system Drag and Drop, ponieważ pozwala na bardziej intuicyjną i dynamiczną interakcję użytkownika z systemem wytwarzania przedmiotów.
       -Dzięki temu gracz może fizycznie przeciągać surowce do maszyn, co sprawia, że proces craftingu jest bardziej angażujący i naturalny.

  5. System bonusów  
       -Wprowadziłem dwa specjalne przedmioty wpływające na crafting:  
       -Lucky Charm → Zwiększa szansę sukcesu o +10%.  
       -Time Amulet → Skraca czas przetwarzania o 2 sekundy (ale nie poniżej 1 sekundy).
     
  6. Decyzje techniczne  
       W trakcie tworzenia projektu podjąłem kilka nietypowych decyzji:  
       - System questów zarządzany dynamicznie → Questy są monitorowane w czasie rzeczywistym i usuwane, gdy są ukończone.  
       - Interfejs maszyn wspólny dla wszystkich → Zamiast osobnych paneli, wszystkie maszyny korzystają z jednego systemu UI.  
       - Obsługa kopiowania przedmiotów w ekwipunku → Jeśli gracz przeciąga przedmiot, który ma większą ilość, tworzy się jego kopia zamiast usuwania całego stosu.
     
  7. Możliwe usprawnienia  
       - Animacje interfejsu → Można dodać płynniejsze przejścia i efekty wizualne przy wykuwaniu przedmiotów.  
       - Dodatkowe przepisy → Obecny system pozwala łatwo dodać nowe przedmioty i maszyny.  
       - Dźwięki → Obecnie gra nie posiada efektów dźwiękowych, ale można dodać np. dźwięki kuźni i magii.  
       - Tooltipy → Warto dodać podpowiedzi najeżdżając na przedmioty, aby gracz mógł zobaczyć ich opis i zastosowanie.  
       - System Drag and Drop → Obecnie nie przeciągamy całego stosu przedmiotów, jeśli mamy więcej niż 1, tylko pojedynczy egzemplarz – warto dodać lepszą informację wizualną na ten temat.  
       - Powiadomienia o craftingu → Przydałyby się modale lub popupy, które informują gracza, czy crafting się powiódł, czy nie, oraz co stało się z jego przedmiotami.  
 




   
