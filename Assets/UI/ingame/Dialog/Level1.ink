// Deskripsi suasana (bisa dipicu untuk muncul sebagai pesan sistem/notifikasi)
* [Lihat kondisi buruh]
    Kulit buruh terlihat merah dan iritasi. #Narrative
    -> percakapan_utama

=== percakapan_utama ===
Buruh: "Eh, Mas. Kira-kira nasi bisa bikin gatal ngga, ya?" #NPC

+ [Balas: "Maaf, Pak..."]
    Pemain: "Maaf, Pak. Saya belum pernah ketemu orang yang alergi nasi." #Player
    -> respon_buruh_soal_kebersihan

=== respon_buruh_soal_kebersihan ===
Buruh: "Kalau begitu mungkin gara-gara toilet dan loker yang kotor." #NPC
Buruh: "Temanku bilang ada bangkai tikus yang dibiarkan seminggu." #NPC

+ [Balas: "Waduh, kok bisa?"]
    Pemain: "Waduh, kok bisa sampai seperti itu?" #Player
    -> penjelasan_buruh_fasilitas

=== penjelasan_buruh_fasilitas ===
Buruh: "Petugas kebersihan makin sedikit sejak dua tahun lalu." #NPC
Pemain: "Loh tempat sebesar ini masa petugas kebersihan sedikit?" #Player
Buruh: "Sekarang mereka cuma ada di kantor pusat." #NPC

// Pilihan ganda untuk menentukan arah pembicaraan
+ [Balas: "Sudah lapor ke atasan?"]
    Pemain: "Sudah pernah lapor ke atasan, Pak?" #Player
    Buruh: "Aduh, Mas. Kalau lapor lapor gitu saya takut." #NPC
    Buruh: "Ya sudah saya permisi dulu, ya." #NPC
    -> penutup

+ [Balas: "Harusnya ada pembersih..."]
    Pemain: "Waduh, harusnya ada pembersih di tiap sektor." #Player
    Buruh: "Iya, Mas. Harusnya memang seperti itu." #NPC
    Buruh: "Ya sudah saya permisi dulu, ya." #NPC
    -> penutup

=== penutup ===
+ [Ucapkan: "Semoga cepat sembuh"]
    Pemain: "Iya, Pak. Semoga cepat sembuh." #Player
    Buruh: "Terimakasih, Mas." #NPC
    -> END