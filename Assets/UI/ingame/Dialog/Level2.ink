// Deskripsi suasana
* [Lihat kondisi buruh]
    Buruh terlihat sangat kelelahan dan rompi robek. #Narrative
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
    Buruh: "Iya, Mas. Saya kerja dari kemarin malam." #NPC
    Buruh: "Bayangkan secapek apa saya sekarang." #NPC
-> pilihan_jam_kerja_atau_APD

// Pilihan untuk membahas APD atau Jam Kerja
=== pilihan_jam_kerja_atau_APD ===
+ [Tanya soal jam kerja]
    -> bahasan_jam_kerja

+ [Tanya soal rompi sobek]
    -> bahasan_apd

=== bahasan_jam_kerja ===
Pemain: "Kok bisa dari kemarin malam, pak? Lama sekali itu." #Player
Buruh: "Terpaksa, mas, kalau ngga nambah jam kerja nanti bisa kehilangan kerjaan." #NPC
Buruh: "Semua di sini nasibnya ya seperti saya ini" #NPC
Pemain: "Waduh, memang tidak ada pembatasan jam kerja, Pak?" #Player
Buruh: "Kami cuma bisa ikut perintah dari yang di atas saja, mas." #NPC
Pemain: "Wah setahu saya bukannya dari pemerintah sudah ada aturannya ya, pak?" #Player
Pemain: "Normalnya 8 jam kerja dan lembur maksimal 4 jam." #Player
Buruh: "Iya, memang harusnya ada pembatasan jam kerja seperti itu, Mas." #NPC
Pemain: "Tapi bapak malah kerja lebih dari 12 jam sampai rompinya robek." #Player
Buruh: "Oh, ini udah lama, Mas. Sudah dari bulan lalu." #NPC
Pemain: "Dari pihak pabrik, ngga ada yang ngurus atau bagaimana?" #Player
Buruh: "Mana ada, Mas. Kami tetap disuruh pakai yang ada." #NPC
Pemain: "Padahal APD rusak harusnya diganti demi keselamatan pekerja." #Player
Buruh: "Saya bingung juga, Mas. Itu udah keputusan dari sananya." #NPC
Pemain: "Pelanggaran lagi itu, Pak." #Player
Pemain: "Perusahaan wajib melaksanakan manajemen APD." #Player
-> penutup

=== bahasan_apd ===
Pemain: "Kerja terus sampai rompinya sampai sobek gitu, Pak?" #Player
Buruh: "Sudah lama, Mas. Sudah dari bulan lalu." #NPC
Pemain: "Dari pihak pabrik, ngga ada yang ngurus APD-nya atau bagaimana?" #Player
Buruh: "Katanya keputusan dari atas, jadi kami cuma pakai yang ada." #NPC
Pemain: "Padahal perusahaan wajib ngecek dan mengganti APD yang rusak, Pak." #Player
Buruh: "Setau saya juga gitu, mas, tapi kami pekerja cuma bisa ngikut atasan saja." #NPC
Pemain: "Waduh, padahal peraturan dari menteri tenaga kerja ada." #Player
Pemain: "Alat pelindungan diri harus dirawat yang tidak layak guna disingkirkan." #Player
Buruh: "Benar, mas, biar tetep aman dan kerasa nyaman kalau dipakai kerja lama." #NPC
Pemain: "Tapi bapak kerja kemarin malam, peraturan perusahaan memang seperti itu?" #Player
Buruh: "Iya, Mas. Kalau nggak ambil lembur takut kehilangan kerja." #NPC
Pemain: "Berarti bisa lebih dari 12 jam kerja?" #Player
Buruh: "Sering begitu, Mas. Banyak teman juga yang ngalamin." #NPC
Pemain: "Waduh, pelanggaran lagi itu." #Player
Pemain: "Sekalipun lembur masa lebih dari 12 jam." #Player
Buruh: "Saya bingung juga, Mas. Itu udah keputusan dari sananya." #NPC
Pemain: "Padahal ada peraturan tertulisnya itu." #Player
-> penutup

=== penutup ===
Buruh: "Harusnya juga seperti itu. Kalau peraturan dilanggar, ya jadinya ya seperti ini, Mas." #NPC

+ [Balas: "Perlu penegakan hukum"]
    Pemain: "Iya, Pak. Perlu ada penegakan hukum yang kuat." #Player
    Pemain: "Silakan istirahat dulu dan nikmati makanannya, Pak." #Player
    -> END