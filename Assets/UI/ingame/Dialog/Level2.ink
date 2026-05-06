// Deskripsi suasana
* [Lihat kondisi buruh]
    Buruh terlihat sangat kelelahan dan rompi yang dikenakannya tampak robek di beberapa bagian. #Narrative
    -> percakapan_utama

=== percakapan_utama ===
Buruh: "Waahhh, makanannya selalu keliatan enak, Mas. Porsinya juga mantap!" #NPC

+ [Balas: "Hahaha, lumayan..."]
    Pemain: "Hahaha, lumayan buat nambah tenaga, Pak." #Player
    Buruh: "Iya, Mas. Udah beneran banting tulang ini." #NPC
    -> tanya_beban_kerja

=== tanya_beban_kerja ===
+ [Balas: "Kelihatannya kok kerjanya.."]
    Pemain: "Kelihatannya kok kerjanya berat sekali, Pak?" #Player
    Buruh: "Iya, Mas. Saya kerja dari kemarin malam. Bayangkan secapek apa saya sekarang." #NPC
-> pilihan_jam_kerja_atau_APD
`
// Pilihan untuk membahas APD atau Jam Kerja
=== pilihan_jam_kerja_atau_APD ===
+ [Tanya soal jam kerja]
    -> bahasan_jam_kerja

+ [Tanya soal rompi sobek]
    -> bahasan_apd

=== bahasan_jam_kerja ===
Pemain: "Dari kemarin malam? Kerja lebih dari 12 jam? Peraturan perusahaan memang seperti itu atau gimana, Pak?" #Player
Buruh: "Iya, kalau ngga nambah jam kerja, nanti bisa kehilangan kerjaan, Mas. Sebenarnya banyak juga yang senasib kerja dari kemarin malam." #NPC
Pemain: "Waduh, memang tidak ada pembatasan jam kerja, Pak?" #Player
Buruh: "Saya bingung juga, Mas. Itu udah keputusan dari sananya." #NPC
Pemain: "Soalnya ada peraturan pemerintah, Pak. Dalam PP Nomor 35 Tahun 2021, maksimal itu 8 jam sehari dan lembur maksimal 4 jam. Jadi totalnya maksimal 12 jam sehari." #Player
Buruh: "Iya, memang harusnya ada pembatasan seperti itu, Mas. Biar tetep aman dan kerasa nyaman kalau dipakai kerja lama." #NPC
-> penutup

=== bahasan_apd ===
Pemain: "Tapi Bapak malah kerja lebih dari 12 jam sampai rompinya robek begitu." #Player
Buruh: "Oh, ini udah lama, Mas. Sudah dari bulan lalu. Kurang nyaman juga jadinya." #NPC
Pemain: "Dari pihak pabrik, ngga ada yang ngurus APD-nya atau bagaimana?" #Player
Buruh: "Saya bingung juga, Mas. Itu udah keputusan dari sananya." #NPC
Pemain: "Padahal di Permenakertrans No. 8 Tahun 2010 tentang APD, pengusaha wajib melaksanakan manajemen APD. Mulai dari merawat, mengecek, sampai menghancurkan APD yang sudah tidak layak guna." #Player
-> penutup

=== penutup ===
Buruh: "Saya setuju saja dengan peraturan itu. Harusnya juga seperti itu. Kalau peraturan dilanggar, ya jadinya ya seperti ini, Mas." #NPC

+ [Balas: "Perlu penegakan hukum"]
    Pemain: "Iya, Pak. Perlu ada penegakan hukum yang kuat. Silakan istirahat dulu dan nikmati makanannya, Pak." #Player
    -> END