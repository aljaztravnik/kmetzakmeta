# kmetzakmeta
Developers:
- Aljaž Travnik 63220337
- Klaudija Jakše 63220115

Sistem za spletno trgovino in pregled cen v sklopu živinoreje in kmetijske mehanizacije KmetZaKmeta uporabnikom nudi objavo oglasa za prodajo živine (posamezne ali masovno) za rejenje, pašo ali zakol. Podrobnosti oglasa vključujejo starost živali, pasmo, težo, ali je posamezna žival že imela naraščaj in zgodovino storitev, ki so jih živali prejele s strani veterinarskih služb.

Uporabnik lahko objavi tudi oglas za novo ali rabljeno kmetijsko mehanizacijo, ki pripada določenemu koraku oz. rabi v kmetijstvu kateremu je oprema namenjena. Tukaj je važno našteti model, moč, težo, št. delovnih ur, ki jih ima stroj, servisiranje, hramba, starost, …

Dostopen je ogled uporabnikovega profila, ki si ga lahko oblikujejo po želji (slika posestva, glavna obrtna dejavnost, drugi podatki o kmetiji).

Cilj projekta je ustvariti mesto, kjer se kmetovalci povezujejo med seboj in imajo boljši pregled nad trgom. Tako se lahko zagotovi, da uporabnik vedno dobi pravično in konkurenčno ceno za svoje potrebe.

Delitev dela med člani ekipe:
    - Aljaž: kontrolerji, html(oglasi), oblak Azure
    - Klaudija: komponente in izgled spletne strani, podatkovna baza
    - Skupaj: avtentikacija (login/register)

V podatkovni bazi imava tabele:
    - Users
    - Regija
    - OglasStroj
    - KategorijaStroji
    - Znamka
    - OglasZivina
    - Pasma

