// --- Narasi Awal ---
* [Lihat kondisi buruh]
    Buruh terlihat memar di kepala. #Narrative
    -> tanya_memar

=== tanya_memar ===
Pemain: "Itu kenapa bisa memar, Pak?" #Player
Buruh: "Iya, ini gara-gara tadi di gudang." #NPC
+ [Tanya langsung: "Ketimpa barang atau gimana, Pak?"]
    Pemain: "Ketimpa barang atau gimana, Pak?" #Player
    -> respon_gudang
+ [Tanya langsung: "Ngga dapat APD atau gimana, Pak?"]
    Pemain: "Ngga dapat APD atau gimana, Pak?" #Player
    -> respon_gudang

=== respon_gudang ===
Buruh: "Bukan. Ini gara-gara kena tampar orang." #NPC

+ [Tanya: Ditampar? Sama atasan?]
    Pemain: "Ditampar? Sama atasan?" #Player
    -> cek_apd
+ [Tanya: Ditampar sama istri, Pak?]
    Pemain: "Ditampar sama istri, Pak?" #Player
    -> cek_apd

=== cek_apd ===
+ [Tanya soal APD]
    Pemain: "Apa Bapak ngga dapat APD (helm pelindung) atau gimana dari kantor, Pak?" #Player
    -> kebenaran_tamparan
+ [Tanya kronologi]
    Pemain: "Memang tadi tidak pakai pelindung kepala saat di gudang?" #Player
    -> kebenaran_tamparan

=== kebenaran_tamparan ===
Buruh: "Bukan, ditampar karena berkelahi sama rekan kerja aja." #NPC 
-> respon_pelaku

=== respon_pelaku ===
Pemain: "Terus kenapa, pak?" #Player
Buruh: "Aku tidak sudi dia tiba-tiba dapat bonus dari atasan." #NPC
Buruh: "Padahal aku yang terus memperbaiki kesalahannya dan tidak dapat tambahan upah sedikitpun." #NPC
Pemain: "Ohh, mungkin karena prestasi dia lagi bagus, Pak? Makanya dapat bonus." #Player
    -> fakta_rekan_kerja

=== fakta_rekan_kerja ===
Buruh: "Prestasi? Dia cuma ngomel-ngomel membela atasannya saja. Kerjaannya juga tidak sesuai prosedur." #NPC

+ [Komentari budaya penjilat]
    Pemain: "Yahh, penjilat. Masih jadi budaya di negeri ini." #Player
    -> akhir_percakapan

=== akhir_percakapan ===
Buruh: "Ya begitulah, Mas. Kenyataannya pahit. Saya duluan, ya." #NPC

+ [Lepas keberangkatan]
    Pemain: "Iya, Pak. Hati-hati di jalan. Semoga lukanya cepat sembuh." #Player
    -> END