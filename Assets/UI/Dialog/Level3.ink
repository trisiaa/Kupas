// --- Narasi Awal ---
* [Lihat kondisi buruh]
    Buruh masuk dengan langkah gontai. Terlihat luka memar yang cukup jelas di bagian kepalanya. #Narrative
    -> tanya_memar

=== tanya_memar ===
+ [Tanya langsung: "Kenapa memar?"]
    Pemain: "Aduh, itu kenapa bisa sampai memar begitu kepalanya, Pak?" #Player
    -> respon_gudang
+ [Tanya dengan nada khawatir]
    Pemain: "Bapak tidak apa-apa? Itu kepalanya biru begitu, kenapa Pak?" #Player
    -> respon_gudang

=== respon_gudang ===
Buruh: "Iya, ini gara-gara tadi di gudang, Mas." #NPC

+ [Tanya kemungkinan kecelakaan]
    Pemain: "Ketimpa barang atau gimana, Pak? Kok bisa sampai luka begitu?" #Player
    -> cek_apd
+ [Tanya soal keamanan]
    Pemain: "Jatuh di gudang, Pak? Kok nampaknya sakit sekali itu." #Player
    -> cek_apd

=== cek_apd ===
+ [Tanya soal APD]
    Pemain: "Apa Bapak ngga dapat APD (helm pelindung) atau gimana dari kantor, Pak?" #Player
    -> kebenaran_tamparan
+ [Tanya kronologi]
    Pemain: "Memang tadi tidak pakai pelindung kepala saat di gudang?" #Player
    -> kebenaran_tamparan

=== kebenaran_tamparan ===
Buruh: "Bukan, Mas. Ini gara-gara kena tampar orang." #NPC

+ [Duga atasan yang melakukan]
    Pemain: "Ditampar? Jangan-jangan sama atasan Bapak?" #Player
    -> respon_pelaku
+ [Coba bercanda (skenario istri)]
    Pemain: "Ditampar sama istri di rumah ya, Pak? Sampai memar begitu." #Player
    -> respon_pelaku

=== respon_pelaku ===
Buruh: "Bukan, ditampar karena berkelahi sama rekan kerja aja." #NPC
Buruh: "Aku tidak sudi dia tiba-tiba dapat bonus dari atasan. Padahal aku yang terus memperbaiki kesalahannya dan tidak dapat tambahan upah sedikitpun." #NPC

+ [Coba berprasangka baik]
    Pemain: "Ohh, mungkin karena prestasi dia lagi bagus, Pak? Makanya dapat bonus." #Player
    -> fakta_rekan_kerja
+ [Tanya kualitas kerja rekan tersebut]
    Pemain: "Memang dia kerjanya lebih baik dari Bapak sampai dapat bonus?" #Player
    -> fakta_rekan_kerja

=== fakta_rekan_kerja ===
Buruh: "Prestasi? Dia cuma ngomel-ngomel membela atasannya saja. Kerjaannya juga tidak sesuai prosedur." #NPC

+ [Komentari budaya penjilat]
    Pemain: "Yahh, penjilat. Masih jadi budaya yang kuat ya di negeri ini." #Player
    -> akhir_percakapan
+ [Beri simpati atas ketidakadilan]
    Pemain: "Miris ya Pak. Yang kerja keras malah kalah sama yang pinter cari muka." #Player
    -> akhir_percakapan

=== akhir_percakapan ===
Buruh: "Ya begitulah, Mas. Kenyataannya pahit. Saya duluan, ya." #NPC

+ [Lepas keberangkatan]
    Pemain: "Iya, Pak. Hati-hati di jalan. Semoga lukanya cepat sembuh." #Player
    -> END