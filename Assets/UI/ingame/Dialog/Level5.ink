// Deskripsi suasana
* [Lihat kondisi pekerja]
    Seorang pekerja kantor berbaju rapi sedang menatap ke arah luar dengan tatapan lesu. #Narrative
    -> percakapan_utama

=== percakapan_utama ===
Pekerja: "Mas, rasanya semakin lama, sungai sama air lautnya semakin keruh, ya, Mas." #NPC

+ [Balas: "Memang keruh, Pak..."]
    Pemain: "Maaf, Pak. Saya sebenarnya pendatang baru di sini. Tapi kalau dilihat, memang airnya keruh semua, Pak." #Player
    Pekerja: "Ohh... Maaf, ya, Mas. Saya belum bisa menolong lebih banyak lagi." #NPC
    Pemain: "Maksudnya, Pak?" #Player
    Pekerja: "Sebenarnya sungai-sungai di sini itu bisa lebih terjaga lagi dan tidak sampai separah ini. Saya merasa bersalah karena tidak bisa mengorbankan perkejaan saya untuk menjaga alam di Morowali." #NPC
    -> pilihan_serius_atau_bercanda

=== pilihan_serius_atau_bercanda ===
+ [Tanya: "Mengorbankan pekerjaan?.."]
    -> pilihan_serius
+ [Tanya: "Merasa bersalah?.."]
    -> pengakuan_bercanda

=== pilihan_serius ===
Pemain: "Mengorbankan pekerjaan? Apa Bapak pernah diancam?" #Player
Pekerja: "Hahaha... jangan kira hanya buruh saja yang terancam di sini. Pekerja seperti saya juga bisa hilang dalam satu malam." #NPC
Pekerja: "Perlu ada seseorang yang bisa menyelamatkan alam Morowali." #NPC

+ [Tawarkan bantuan]
    Pemain: "Ehh? Mungkin ada yang bisa saya bantu, Pak? Saya juga risih dengan permasalahan yang muncul dari pabrik itu." #Player
    Pekerja: "Kamu yakin? Bisa saja warungmu besok sudah rata dengan tanah, lho." #NPC
    -> reveal_akuntan

=== pengakuan_bercanda ===
Pemain: "Merasa bersalah? Apa yang terjadi, Pak?" #Player
Pekerja: "Sebenarnya, saya adalah Betmen." #NPC
Pemain: "Wah, serius, Pak?" #Player
Pekerja: "Ngga, bercanda. Saya cuma bagian akuntan." #NPC
Pemain: "Oh, kukira beneran Betmen yang berhadapan langsung dengan kejahatan."#Player
Pekerja: "Lho, saya memang seperti itu. Bahkan saya pernah melihat dan berurusan dengan bukti kejahatannya langsung." #NPC
    -> reveal_akuntan

=== reveal_akuntan ===
+ ["Waduh, ngeri juga ya.."]
Pemain: "Waduh, ngeri juga, ya. Tapi, saya jadi penasaran." #Player
-> penyerahan_dokumen

=== penyerahan_dokumen ===
* [Terima dokumen dari Pekerja]
    Pekerja memberikan sebuah dokumen penting kepada Pemain. #Narrative
    Pekerja: "Ini, saya ada titipan buatmu. Terserah mau kamu bakar atau kamu terbangkan sampai ke ujung langit." #NPC
    Pekerja: "Apapun yang kamu lakukan dengan kertas ini, konsekuensi ada di tanganmu." #NPC
    -> penutup

=== penutup ===
Pekerja: "Saya sudah bingung mau bagaimana lagi. Jam makan siang mau habis, saya pergi dulu ya." #NPC

+ [Balas: "Iya, Pak"]
    Pemain: "Iya, Pak. Hati-hati." #Player
    -> END