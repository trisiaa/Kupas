// Deskripsi suasana (bisa dipicu untuk muncul sebagai pesan sistem/notifikasi)
* [Lihat kondisi buruh]
    Kulit buruh terlihat merah dan iritasi.
    -> percakapan_utama

=== percakapan_utama ===
Buruh: "Eh, Mas. Kira-kira nasi bisa bikin gatal ngga, ya?"

+ [Balas: "Maaf, Pak..."]
    Pemain: "Maaf, Pak. Saya belum pernah ketemu orang yang alergi nasi."
    -> respon_buruh_soal_kebersihan

=== respon_buruh_soal_kebersihan ===
Buruh: "Hmm, kalau gitu apa mungkin karena toilet dan ruang loker yang kotor, ya? Bahkan temanku bilang ada bangkai tikus yang tergeletak seminggu."

+ [Balas: "Waduh, kok bisa?"]
    Pemain: "Waduh, kok bisa sampai seperti itu?"
    -> penjelasan_buruh_fasilitas

=== penjelasan_buruh_fasilitas ===
Buruh: "Gatau, Mas. Semenjak 2 tahun lalu, tukang bersih-bersih semakin sedikit dan cuma ada di kantor pusat saja."

// Pilihan ganda untuk menentukan arah pembicaraan
+ [Balas: "Sudah lapor ke atasan?"]
    Pemain: "Sudah pernah lapor ke atasan, Pak?"
    Buruh: "Aduh, Mas. Kalau lapor lapor gitu saya takut. Ya sudah saya permisi dulu, ya."
    -> penutup

+ [Balas: "Harusnya ada pembersih..."]
    Pemain: "Waduh, harusnya ada pembersih di tiap sektor."
    Buruh: "Iya, Mas. Harusnya memang seperti itu. Ya sudah saya permisi dulu, ya."
    -> penutup

=== penutup ===
+ [Ucapkan: "Semoga cepat sembuh"]
    Pemain: "Iya, Pak. Semoga cepat sembuh."
    Buruh: "Terimakasih, Mas."
    -> END