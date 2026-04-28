// --- Narasi Awal ---
* [Lihat kondisi buruh]
    Buruh terlihat sangat kelelahan. Rompi yang dikenakannya tampak sobek di beberapa sisi. #Narrative
    -> sapaan_awal

=== sapaan_awal ===
Buruh: "Waahhh, makanannya selalu keliatan enak mas. Porsinya juga mantap." #NPC

+ [Balas: "Lumayan buat tenaga"]
    Pemain: "Hahaha, lumayan buat nambah tenaga, Pak. Harus kenyang kalau mau lanjut lagi." #Player
    -> banting_tulang
+ [Balas: "Porsi spesial untuk Bapak"]
    Pemain: "Sengaja saya banyakin Pak, supaya Bapak ada tenaga ekstra hari ini." #Player
    -> banting_tulang

=== banting_tulang ===
Buruh: "Iya, Mas. Udah beneran banting tulang ini." #NPC

+ [Tanya: "Kerjanya berat sekali, Pak?"]
    Pemain: "Kelihatannya kok kerjanya berat sekali, Pak? Sampai keringetan begitu." #Player
    -> durasi_kerja
+ [Tanya: "Bapak sudah kerja berapa lama?"]
    Pemain: "Baru selesai shift, Pak? Kelihatannya Bapak lelah sekali." #Player
    -> durasi_kerja

=== durasi_kerja ===
Buruh: "Iya, Mas. Saya kerja dari kemarin malam. Bayangkan secapek apa saya sekarang." #NPC

+ [Tanya soal aturan 12 jam]
    Pemain: "Dari kemarin malam? Kerja lebih dari 12 jam? Peraturan perusahaan memang seperti itu atau gimana, Pak?" #Player
    -> alasan_buruh
+ [Tanya soal alasan lembur]
    Pemain: "Waduh, apa memang tidak ada pembatasan jam kerja di pabrik, Pak?" #Player
    -> alasan_buruh

=== alasan_buruh ===
Buruh: "Iya, kalau ngga nambah jam kerja, nanti bisa kehilangan kerjaan, Mas. Sebenarnya banyak juga yang senasib kerja dari kemarin malam. Itu udah keputusan dari sananya." #NPC

+ [Beri tahu aturan PP No. 35 Tahun 2021]
    Pemain: "Tapi Pak, ada peraturan pemerintah. Dalam PP Nomor 35 Tahun 2021, kerja itu maksimal 8 jam sehari untuk 5 hari kerja." #Player
    Pemain: "Lembur pun maksimal cuma 4 jam. Jadi totalnya tidak boleh lewat 12 jam sehari." #Player
    -> respon_jam_kerja
+ [Kritik kebijakan perusahaan]
    Pemain: "Harusnya perusahaan nggak boleh asal paksa lembur, Pak. Ada batas maksimal 12 jam sehari menurut aturan pemerintah." #Player
    -> respon_jam_kerja

=== respon_jam_kerja ===
Buruh: "Iya, memang harusnya ada pembatasan seperti itu, Mas." #NPC
-> diskusi_apd

=== diskusi_apd ===
+ [Komentari rompi: "Sampai rompinya robek..."]
    Pemain: "Tapi Bapak malah kerja sampai lebih dari 12 jam, lihat itu rompinya sampai robek (orbek) begitu." #Player
    -> kondisi_rompi
+ [Tanya: "Rompinya kenapa, Pak?"]
    Pemain: "Itu rompinya sobek karena kerja lembur terus, Pak?" #Player
    -> kondisi_rompi

=== kondisi_rompi ===
Buruh: "Oh, ini udah lama, Mas. Sudah dari bulan lalu. Kurang nyaman juga jadinya." #NPC

+ [Tanya soal tanggung jawab pabrik]
    Pemain: "Dari pihak pabrik, ngga ada yang ngurus APD-nya atau bagaimana? Kok dibiarkan rusak?" #Player
    -> penjelasan_apd
+ [Beri tahu aturan APD]
    Pemain: "Pihak pabrik harusnya bertanggung jawab atas kondisi rompi Bapak itu." #Player
    -> penjelasan_apd

=== penjelasan_apd ===
Buruh: "Saya bingung juga, Mas. Itu udah keputusan dari sananya." #NPC

+ [Kutip aturan Permenakertrans No. 8/2010]
    Pemain: "Soalnya, dalam Permenakertrans No. 8 Tahun 2010, pengusaha wajib melaksanakan manajemen APD." #Player
    Pemain: "Mereka harus merawat, mengecek, bahkan menghancurkan APD yang tidak layak guna untuk diganti yang baru." #Player
    -> respon_akhir
+ [Tekankan kewajiban pengusaha]
    Pemain: "Aturannya jelas Pak, pengusaha wajib mengecek dan mengganti APD yang sudah tidak layak pakai seperti rompi Bapak ini." #Player
    -> respon_akhir

=== respon_akhir ===
Buruh: "Iya, memang harusnya ada pembatasan seperti itu, Mas. Biar tetep aman dan kerasa nyaman kalau dipakai kerja lama." #NPC
Buruh: "Saya setuju saja dengan peraturan itu. Harusnya juga seperti itu. Kalau peraturan dilanggar, ya jadinya ya seperti ini, mas." #NPC

+ [Selesaikan pembicaraan: Fokus Hukum]
    Pemain: "Betul, Pak. Perlu ada penegakan hukum yang kuat agar pekerja tidak dirugikan. Silakan dinikmati makanannya." #Player
    -> END
+ [Selesaikan pembicaraan: Fokus Istirahat]
    Pemain: "Iya, Pak. Yang penting sekarang Bapak istirahat dulu dan nikmati makannya sampai kenyang." #Player
    -> END