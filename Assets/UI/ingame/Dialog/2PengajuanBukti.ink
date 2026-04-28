* [Lapor hasil investigasi ke Bos]
    Mari kita sampaikan temuan di Morowali. #Narrative
    -> laporan_awal

=== laporan_awal ===
Boss: "Bagaimana kelanjutan laporanmu dari Morowali? Sudah ada perkembangan terbaru dari informasi buruh yang kemarin?" #NPC

+ [Balas: "Keadaannya semakin keruh, Bos."]
    Pemain: "Keadaannya semakin keruh, Bos. Saya baru saja mendapatkan informasi mengenai kejanggalan anggaran perusahaan dan dampaknya ke lingkungan sekitar." #Player
    -> respon_bos_anggaran

=== respon_bos_anggaran ===
Boss: "Kejanggalan anggaran? Itu tuduhan serius. Apa kamu punya bukti otentik soal permainan anggaran mereka?" #NPC
    -> pilihan_bukti_anggaran

=== pilihan_bukti_anggaran ===
+ [Bukti: CASE PAK BENI: "UNION BUSTING" ]
    Pemain: "Ini bukti yang saya dapatkan dari lapangan, Bos." #Player
    Boss: "Apa ini? Aku tidak paham maksudmu. Dokumen anggaran yang aku minta!" #NPC
    -> pilihan_bukti_anggaran

+ [Bukti: CASE PAK ANTON: "REGULASI" ]
    Pemain: "Saya bertemu seorang akuntan yang merasa bersalah karena tidak bisa menjaga alam Morowali. Dia memberikan dokumen rahasia ini kepada saya yang berisi bukti kejahatan anggaran perusahaan." #Player
    Boss: "Kalau dokumen ini asli, berarti mereka memang sengaja mengabaikan regulasi lingkungan demi keuntungan. Apa ada temuan lain?" #NPC
    -> investigasi_gaya_hidup

=== investigasi_gaya_hidup ===
+ [Ceritakan tentang ketimpangan sosial]
    Pemain: "Sangat banyak, Bos. Anggaran yang harusnya untuk hak buruh sepertinya lari ke kantong pribadi." #Player
    Pemain: "Ada buruh yang gajinya ditahan terus sampai tidak bisa bayar makan. Padahal, para petinggi pabrik di sana pulang pergi naik mobil mewah seharga 8,5 Miliar. Benar-benar tidak ada keadilan bagi buruh di sana." #Player
    -> respon_bos_mobil

=== respon_bos_mobil ===
Boss: "Ah, masa bisa sampai seperti itu? Itu kan korupsi terang terangan. Kamu ada buktinya, tidak?" #NPC
    -> pilihan_bukti_mobil

=== pilihan_bukti_mobil ===
+ [Bukti: CASE IBU DENIS: "KORUPSI" ]
    Pemain: "Ini datanya, Bos. Terverifikasi atas nama perusahaan namun digunakan untuk pribadi." #Player
    Boss: "Wow, mobilku saja tidak sebagus ini. Tapi kenapa para buruh tidak ada yang melapor? Apa buruh diam saja?" #NPC
    -> kondisi_buruh

+ [Bukti: CASE PAK JUAN: "OVERWORKED/APD" ]
    Pemain: "Ini foto APD yang rusak, Bos." #Player
    Boss: "Apa ini? Aku tidak paham maksudmu. Fokus ke masalah gaya hidup mewah mereka dulu!" #NPC
    -> pilihan_bukti_mobil

=== kondisi_buruh ===
+ [Ceritakan tentang penindasan]
    Pemain: "Mereka tidak diam, tapi mereka ditindas. Saya melihat buruh dengan luka memar di kepala karena ditampar setelah protes soal ketidakadilan upah." #Player
    -> penyerahan_rekaman

=== penyerahan_rekaman ===
* [Berikan rekaman suara Union Busting]
    Pemain memberikan rekaman suara kepada Bos. #Narrative
    Pemain: "Ada praktik union busting; mereka yang menjilat dan membela atasan diberikan bonus, sedangkan yang bekerja sesuai prosedur tapi kritis justru diperas habis-habisan." #Player
    -> kesimpulan_bos

=== kesimpulan_bos ===
Boss: "Situasinya jauh lebih berbahaya dari yang saya kira. Ada kekerasan fisik dan manipulasi sistematis di sana." #NPC

+ [Balas: "Betul, Bos. Ada nyawa yang terancam."]
    Pemain: "Betul, Bos. Bahkan ada akuntan yang bisa terancam kalau mereka tahu dia menyelidiki ini." #Player
    -> resolusi_akhir

=== resolusi_akhir ===
Boss: "Kejahatan ini sudah benar-benar terlihat jelas sekarang. Sudah kuduga kasus tahun lalu itu benar-benar terjadi bahkan hingga saat ini." #NPC
Boss: "Akan aku cek anggaran dan birokrasi mereka. Pasti si dalang akan langsung tertangkap." #NPC

+ [Selesaikan Laporan]
    Tugas di Morowali kini masuk ke tahap hukum yang lebih tinggi. #Narrative
    -> END