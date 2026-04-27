// --- Narasi Awal ---
* [Lihat kondisi Ibu Buruh]
    Seorang buruh wanita masuk dengan wajah yang tampak campur aduk antara bingung dan jengkel. #Narrative
    -> permintaan_bayar

=== permintaan_bayar ===
Buruh: "Mas, maaf... bayarnya bisa minggu depan, tidak?" #NPC

+ [Bolehkan: "Boleh, Bu..."]
    Pemain: "Oh, boleh, Bu. Tidak apa-apa kasbon saja dulu." #Player
    -> alasan_tunggakan
+ [Tanya alasan: "Ada masalah, Bu?"]
    Pemain: "Minggu depan? Tentu boleh, Bu. Tapi kalau boleh tahu, ada apa ya?" #Player
    -> alasan_tunggakan

=== alasan_tunggakan ===
Buruh: "Soalnya anu..." #NPC
Pemain: "Ada apa sebenarnya, Bu?" #Player
Buruh: "Uang saya bulan ini sudah habis, Mas. Saya bingung harus bagaimana lagi." #NPC

+ [Tanya soal gaji]
    Pemain: "Tapi, bukannya gajian baru beberapa hari lalu ya, Bu? Biasanya kan jadwalnya begitu." #Player
    -> masalah_gaji
+ [Tanya kondisi keuangan]
    Pemain: "Waduh, sampai habis sama sekali? Apa ada kebutuhan mendadak, Bu?" #Player
    -> masalah_gaji

=== masalah_gaji ===
Buruh: "Iya, memang seharusnya begitu. Tapi, gatau kenapa, gaji saya masih ditahan terus dan tidak cair-cair." #NPC

+ [Respons kaget]
    Pemain: "Lho, kok malah ditahan!? Alasan mereka apa sampai tidak mencairkan hak Ibu?" #Player
    -> keluhan_keadilan
+ [Respons bingung]
    Pemain: "Kok bisa sampai ditahan begitu? Memangnya ada masalah di pabrik?" #Player
    -> keluhan_keadilan

=== keluhan_keadilan ===
Buruh: "Gimana ya, Mas. Kerja jadi buruh, gaji yang berkecukupan saja tidak cair." #NPC
Buruh: "Apalagi sebagai ibu yang perlu ninggal anak di kampung, rasanya tidak ada keadilan sama sekali di sini." #NPC

+ [Beri empati]
    Pemain: "Astaga... Ibu sudah rela meninggalkan keluarga demi mereka, tapi malah tidak mendapatkan keadilan." #Player
    Pemain: "Pasti membuat Ibu bingung dan merasa dikhianati oleh perusahaan." #Player
    -> bandingkan_atasan
+ [Respons prihatin]
    Pemain: "Tega sekali ya, Bu. Padahal Ibu sudah berkorban jauh dari anak demi mencari nafkah di sini." #Player
    -> bandingkan_atasan

=== bandingkan_atasan ===
Buruh: "Iya, apalagi ngeliat yang kerjaannya cuma nyuruh-nyuruh dan duduk saja itu pulang pergi naik mobil bagus-bagus. Ngurus gaji aja tidak jelas tapi hidup mereka lebih aman." #NPC

+ [Coba menenangkan]
    Pemain: "Ohh, yang sabar aja ya, Bu. Semoga keadaan cepat membaik." #Player
    -> reaksi_jengkel_sabar
+ [Komentari ketimpangan]
    Pemain: "Memang miris ya, Bu. Yang kerja paling keras justru yang paling sulit gajinya." #Player
    -> diskusi_foto

=== reaksi_jengkel_sabar ===
Buruh: "Sabar? Aduh, anak muda ini memang tidak tahu apa-apa tentang tekanan keluarga, ya!" #NPC
Buruh: "Jangan sampai kamu jadi orang-orang yang kerjaannya cuma duduk dan nyuruh-nyuruh saja itu, ya! Pulang pergi naik mobil bagus, ngurus gaji ngga becus." #NPC
-> diskusi_foto

=== diskusi_foto ===
{reaksi_jengkel_sabar: Buruh mengeluarkan sebuah foto dari sakunya dengan tangan gemetar. | Buruh menunjukkan sebuah foto di ponselnya. } #Narrative
Buruh: "Lihat ini, Nak." #NPC

+ [Komentari harga mobil]
    Pemain: "Waduh, mobil mahal-mahal ini. Harusnya ngga perlu mobil semahal ini buat transportasi di Morowali." #Player
    -> info_harga
+ [Tanya kepemilikan mobil]
    Pemain: "Ini mobil milik atasan Ibu? Kelihatan mewah sekali untuk daerah tambang begini." #Player
    -> info_harga

=== info_harga ===
Buruh: "Iya, kata orang itu harganya 8,5 Miliar atau berapa itu." #NPC

+ [Beri makanan gratis]
    Pemain: "Yaudah, Bu. Ini makanannya tidak perlu Ibu bayar. Anggap saja ini dukungan dari saya." #Player
    Pemain: "Semoga gajinya cepat cair ya, Bu. Ibu harus tetap kuat." #Player
    -> penutup
+ [Tolak pembayaran]
    Pemain: "Ibu simpan saja uangnya untuk keperluan lain. Makan hari ini gratis buat Ibu." #Player
    Pemain: "Semoga masalah gajinya segera selesai, Bu." #Player
    -> penutup

=== penutup ===
Buruh: "Oh, iya, Nak, terimakasih banyak. Semoga kamu bisa melancarkan rezeki orang lain juga." #NPC

+ [Balas: "Iya, siap"]
    Pemain: "Iya, siap, terimakasih kembali, Bu. Hati-hati di jalan." #Player
    -> END