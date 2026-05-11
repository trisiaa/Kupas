// Deskripsi suasana
* [Lihat kondisi buruh]
    Buruh terlihat bingung/jengkel. #Narrative
    -> percakapan_utama

=== percakapan_utama ===
Buruh: "Mas, maaf... bayarnya bisa minggu depan, tidak?" #NPC

+ [Balas: "Oh, boleh, Bu..."]
    Pemain: "Oh, boleh, Bu. Tidak apa-apa." #Player
    Buruh: "Soalnya anu..." #NPC
    Pemain: "Ada apa, Bu?" #Player
    Buruh: "Uang saya bulan ini sudah habis, Nak. Saya bingung harus bagaimana lagi." #NPC
    -> bahasan_gaji

=== bahasan_gaji ===
Pemain: "Tapi, bukannya gajian baru beberapa hari lalu, ya, Bu?" #Player
Buruh: "Iya, memang seharusnya begitu. Tapi, gatau kenapa, gaji saya masih ditahan terus dan tidak cair-cair." #NPC

+ [Balas: "Lho, kok ditahan!?"]
    Pemain: "Lho, kok malah ditahan!?" #Player
    Buruh: "Gimana, ya, Nak. Kerja jadi buruh, gaji yang berkecukupan saja tidak cair." #NPC
    Buruh: " Apalagi sebagai ibu yang perlu ninggal anak di kampung, rasanya tidak ada keadilan sama sekali di sini." #NPC
    -> pilihan_simpati_atau_sabar
    
// Pilihan untuk membahas APD atau Jam Kerja
=== pilihan_simpati_atau_sabar ===
+ [Balas: "Astaga... ,ibu sudah rela-rela.."]
    -> simpati_pemain

+ [Balas: "Ohh, yang sabar aja"]
    -> sabar_pemain

=== simpati_pemain ===
Pemain: "Astaga... Ibu sudah rela-rela meninggalkan keluarga demi mereka, tapi malah begini." #Player
Buruh: "Orang seperti saya bisa apa, mas." #NPC
Pemain: "Pasti membuat ibu bingung dan merasa dikhianati." #Player
Buruh: "Iya, apalagi ngeliat yang kerjaannya cuma nyuruh-nyuruh dan duduk saja itu pulang pergi naik mobil bagus-bagus." #NPC
Buruh: " Ngurus gaji aja tidak jelas tapi hidup mereka lebih aman." #NPC
-> tunjukkan_foto

=== sabar_pemain ===
Pemain: "Ohh, yang sabar aja, ya, Bu." #Player
Buruh: "Sabar? Aduh, anak muda ini memang tidak tahu apa-apa tentang tekanan keluarga, ya!" #NPC
Pemain: "Bukan begitu maksud saya, Bu." #Player
Buruh: "Jangan sampai kamu jadi orang-orang yang kerjaannya cuma duduk dan nyuruh-nyuruh saja itu, ya!" #NPC
Buruh: "Pulang pergi naik mobil bagus, ngurus gaji ngga becus." #NPC
-> tunjukkan_foto

=== tunjukkan_foto ===
// Aksi Buruh memberikan foto
* [Lihat foto dari Buruh]
    #img_bubble: foto_mobil
    Buruh menunjukkan sebuah foto mobil mewah di ponselnya. #Narrative
    Pemain: "Waduh, mobil mahal-mahal ini." #Player
      Pemain: "Harusnya ngga perlu mobil semahal ini buat transportasi di Morowali." #Player
    Buruh: "Iya, kata orang itu harganya 8,5 M atau berapa itu." #NPC
    -> penutup

=== penutup ===
+ [Gratiskan makanan]
    Pemain: "Yaudah, Bu. Ini makanannya tidak perlu Ibu bayar." #Player
    Pemain: "Semoga gajinya cepat cair, ya, Bu." #Player
    Buruh: "Oh, iya, Nak, terimakasih banyak." #NPC
    Buruh: "Semoga kamu bisa melancarkan rezeki orang lain juga." #NPC
    Pemain: "Iya, siap, terimakasih, Bu." #Player
    -> END