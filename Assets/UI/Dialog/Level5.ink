// --- Narasi Awal ---
* [Lihat pelanggan baru]
    Seorang pria berbaju kantor rapi masuk. Meskipun pakaiannya bersih, wajahnya tampak memikul beban berat. #Narrative
    -> mulai_percakapan

=== mulai_percakapan ===
Pekerja: "Mas, rasanya semakin lama, sungai sama air lautnya semakin keruh, ya, Mas." #NPC

+ [Setuju: "Memang keruh sekali"]
    Pemain: "Maaf, Pak. Saya sebenarnya pendatang baru di sini. Tapi kalau dilihat-lihat, memang airnya keruh semua sekarang." #Player
    -> respon_maaf
+ [Tanya pendapat: "Apa dulu tidak seperti ini?"]
    Pemain: "Saya baru di sini, Pak. Apa dulu air di Morowali tidak sekeruh ini?" #Player
    -> respon_maaf

=== respon_maaf ===
Pekerja: "Ohh... Maaf, ya, Mas. Saya belum bisa menolong lebih banyak lagi." #NPC

+ [Tanya maksudnya: "Maksudnya, Pak?"]
    Pemain: "Maksudnya bagaimana, Pak? Kenapa Bapak yang minta maaf?" #Player
    -> rasa_bersalah
+ [Tanya keterlibatan: "Bapak kerja di sana?"]
    Pemain: "Apa Bapak bekerja di perusahaan yang menyebabkan ini?" #Player
    -> rasa_bersalah

=== rasa_bersalah ===
Pekerja: "Sebenarnya sungai-sungai di sini itu bisa lebih terjaga lagi dan tidak sampai separah ini." #NPC
Pekerja: "Saya merasa bersalah karena tidak bisa mengorbankan pekerjaan saya untuk menjaga alam di Morowali." #NPC

+ [Tanya soal ancaman]
    Pemain: "Mengorbankan pekerjaan? Apa Bapak pernah diancam oleh pihak atasan?" #Player
    -> ancaman_kantor
+ [Gali rasa bersalahnya]
    Pemain: "Merasa bersalah? Apa sebenarnya yang terjadi di dalam sana, Pak?" #Player
    -> ancaman_kantor

=== ancaman_kantor ===
Pekerja: "Hahaha... jangan kira hanya buruh saja yang terancam di sini. Pekerja seperti saya juga bisa hilang dalam satu malam." #NPC
Pekerja: "Perlu ada seseorang yang bisa menyelamatkan alam Morowali." #NPC

+ [Tawarkan bantuan]
    Pemain: "Ehh? Mungkin ada yang bisa saya bantu, Pak? Saya juga risih dengan permasalahan dari pabrik itu." #Player
    -> risiko_warung
+ [Ragu: "Apa aman membantu?"]
    Pemain: "Bahaya sekali ya, Pak. Tapi kalau dibiarkan terus, alam kita bisa hancur." #Player
    -> risiko_warung

=== risiko_warung ===
Pekerja: "Kamu yakin? Bisa saja warungmu besok sudah rata dengan tanah, lho." #NPC

+ [Tantang balik: "Saya tidak takut"]
    Pemain: "Kalau untuk kebenaran, saya rasa itu risiko yang harus diambil." #Player
    -> lelucon_batman
+ [Tanya identitas: "Bapak siapa sebenarnya?"]
    Pemain: "Bapak bicara seolah tahu segalanya. Bapak ini siapa sebenarnya?" #Player
    -> lelucon_batman

=== lelucon_batman ===
Pekerja: "Sebenarnya... saya adalah Betmen." #NPC

+ [Respons kaget: "Wah, serius Pak?"]
    Pemain: "Wah, serius, Pak? Bapak pahlawan bertopeng itu?" #Player
    -> pengakuan_akuntan
+ [Respons sangsi: "Bapak bercanda ya?"]
    Pemain: "Maksudnya Batman pelindung kota itu? Mana mungkin, Pak." #Player
    -> pengakuan_akuntan

=== pengakuan_akuntan ===
Pekerja: "Ngga, bercanda. Saya cuma bagian akuntan." #NPC

+ [Kecewa: "Kukira beneran..."]
    Pemain: "Yah, saya kira beneran Betmen yang berhadapan langsung dengan kejahatan." #Player
    -> bukti_kejahatan
+ [Komentari pekerjaan: "Hanya akuntan?"]
    Pemain: "Halah, ternyata cuma bagian hitung-menghitung saja ya." #Player
    -> bukti_kejahatan

=== bukti_kejahatan ===
Pekerja: "Lho, saya memang seperti itu. Bahkan saya pernah melihat dan berurusan dengan bukti kejahatannya langsung." #NPC

+ [Respons penasaran]
    Pemain: "Waduh, ngeri juga ya. Tapi... jujur saya jadi penasaran, Pak." #Player
    -> titipan_dokumen
+ [Tanya detail]
    Pemain: "Bukti kejahatan? Apa Bapak punya datanya?" #Player
    -> titipan_dokumen

=== titipan_dokumen ===
Pekerja mengeluarkan sebuah amplop tebal berisi dokumen dari tas kerjanya. #Narrative
Pekerja: "Ini, saya ada titipan buatmu." #NPC
Pekerja: "Terserah mau kamu bakar atau kamu terbangkan sampai ke ujung langit. Apapun yang kamu lakukan dengan kertas ini, konsekuensi ada di tanganmu." #NPC

+ [Terima dokumen]
    Pemain: "Baik, Pak. Saya akan menjaganya. Ini tanggung jawab besar." #Player
    -> perpisahan
+ [Ragu menerima]
    Pemain: "Bapak yakin memberikan ini pada saya? Ini bisa jadi masalah besar buat kita berdua." #Player
    -> perpisahan

=== perpisahan ===
Pekerja: "Saya sudah bingung mau bagaimana lagi. Jam makan siang mau habis, saya pergi dulu, ya, tuan muda." #NPC

+ [Lepas keberangkatan]
    Pemain: "Iya, Pak. Hati-hati di jalan. Terima kasih atas kepercayaannya." #Player
    -> END