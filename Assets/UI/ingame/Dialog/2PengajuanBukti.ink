* [Lapor hasil investigasi ke Bos]
    Mari kita sampaikan temuan di Morowali. #Narrative
    -> laporan_awal

=== laporan_awal ===
Boss: "Bagaimana kelanjutan laporanmu dari Morowali?" #NPC
Boss: "Sudah ada perkembangan terbaru dari informasi buruh yang kemarin?" #NPC

+ ["Keadaannya semakin keruh, Bos."]
    Pemain: "Keadaannya semakin keruh, Bos. Ada kejanggalan dalam anggaran perusahaan yang berdampak ke lingkungan sekitar." #Player
    -> respon_bos_anggaran

=== respon_bos_anggaran ===
Boss: "Kejanggalan anggaran? Itu tuduhan serius." #NPC
Boss: "Apa kamu punya bukti otentik soal permainan anggaran mereka?" #NPC
    -> pilihan_bukti_anggaran

=== pilihan_bukti_anggaran ===
+ [Bukti: CASE PAK BENI: "KEKERASAN PEKERJA" ]
    #img_bubble: foto_rekaman
    Memberikan bukti percakapan dengan Pak Beni. #Narrative
    Pemain: "Ini bukti yang saya dapatkan dari lapangan, Bos." #Player
    Boss: "Apa ini? Aku tidak paham maksudmu. Dokumen anggaran yang aku minta!" #NPC
    -> pilihan_bukti_anggaran

+ [Bukti: CASE PAK ANTON: "BUKTI ANGGARAN" ]
    #img_bubble: foto_anggaran
    Memberikan bukti dokumen anggaran dari Pak Anton. #Narrative
    Pemain: "Saya bertemu akuntan yang terancam pekerjaannya dan dia memberikan dokumen rahasia ini." #Player
    Pemain: "Isinya bukti kejahatan anggaran perusahaan." #Player
    Boss: "Kalau dokumen ini asli, berarti mereka memang sengaja mengabaikan regulasi lingkungan demi keuntungan. Apa ada temuan lain?" #NPC
    -> investigasi_gaya_hidup

=== investigasi_gaya_hidup ===
+ [Ceritakan tentang ketimpangan sosial]
    Pemain: "Sangat banyak, Bos. Anggaran yang harusnya untuk hak buruh sepertinya lari ke kantong pribadi." #Player
    Pemain: "Ada buruh yang gajinya ditahan. Sementara petinggi pabrik di sana pulang pergi naik mobil mewah seharga 8,5 Miliar." #Player
    -> respon_bos_mobil

=== respon_bos_mobil ===
Boss: "Ah, masa bisa sampai seperti itu? Itu kan korupsi terang terangan. Kamu ada buktinya, tidak?" #NPC
    -> pilihan_bukti_mobil

=== pilihan_bukti_mobil ===
+ [Bukti: CASE IBU DENIS: "FOTO MOBIL" ]
    #img_bubble: foto_mobil
    Memberikan bukti dokumen dari informasi Ibu Denis. #Narrative
    Pemain: "Ini datanya, Bos. Terverifikasi atas nama perusahaan namun digunakan untuk pribadi." #Player
    Boss: "Wow, mobilku saja tidak sebagus ini. Tapi kenapa para buruh tidak ada yang melapor? Apa buruh diam saja?" #NPC
    -> kondisi_buruh

+ [Bukti: CASE PAK JUAN: "OVERWORKED/APD" ]
    #img_bubble: foto_rekaman
    Memberikan bukti rekaman percakapan dengan Pak Juan. #Narrative
    Pemain: "Ini foto APD yang rusak, Bos." #Player
    Boss: "Apa ini? Aku tidak paham maksudmu. Fokus ke masalah gaya hidup mewah mereka dulu!" #NPC
    -> pilihan_bukti_mobil

=== kondisi_buruh ===
+ [Ceritakan tentang penindasan]
    Pemain: "Mereka begitu karena ditindas." #Player
    Pemain: "Saya juga lihat buruh dengan luka di kepala karena ditampar setelah protes soal ketidakadilan upah." #Player
    -> penyerahan_rekaman

=== penyerahan_rekaman ===
    #img_bubble: foto_rekaman
* [Berikan rekaman suara Kasus Kekerasan Pekerja]
    Pemain memberikan rekaman suara dari kasus Pak Beni kepada Bos. #Narrative
    Pemain: "Ada praktik union busting; mereka yang menjilat dan membela atasan diberikan bonus." #Player
    Pemain: "Sedangkan yang bekerja sesuai prosedur dan kritis justru diperas habis-habisan." #Player
    -> kesimpulan_bos

=== kesimpulan_bos ===
Boss: "Situasinya jauh lebih berbahaya dari yang saya kira." #NPC
Boss: "Ternyata sampai ada kekerasan fisik dan manipulasi sistematis di sana." #NPC

+ ["Betul, Bos.."]
    Pemain: "Betul, Bos. Semuanya benar-benar terancam di sana." #Player
    -> resolusi_akhir

=== resolusi_akhir ===
Boss: "Sudah kuduga kasus tahun lalu itu benar-benar terjadi bahkan hingga saat ini. Akan aku cek anggaran dan birokrasi mereka." #NPC
Boss: "Pasti si dalang akan langsung tertangkap. Kita sudah punya cukup bukti sekarang." #NPC

+ [Selesaikan Laporan]
    Tugas di Morowali kini masuk ke tahap hukum yang lebih tinggi. #Narrative
    -> END