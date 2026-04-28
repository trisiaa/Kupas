// Deskripsi suasana (bisa dipicu untuk muncul sebagai pesan sistem/notifikasi)
* [Investigasi bersama bos]
    Mari kita kumpulkan bukti-buktinya. #Narrative
    -> percakapan_utama

=== percakapan_utama ===
Bos: "Gimana situasi di Morowali kemarin? Harusnya banyak buruh dari pabrik sebelah yang mampir makan siang di warung." #NPC

+ [Balas: "Cukup banyak, Bos."]
    Pemain: "Cukup banyak, Bos. Tapi sepertinya kondisi sanitasi sedang tidak baik-baik saja." #Player
    -> respon_bos_soal_bukti_investigasi

=== respon_bos_soal_bukti_investigasi ===
Bos: "Sanitasi? Bukannya sanitasi prabrik sudah diperbaiki sejak tahun lalu? Kamu ada buktinya, tidak?" #NPC
    -> pilihan_bukti_pengadilan_pertama

=== pilihan_bukti_pengadilan_pertama ===
// Pilihan ganda untuk menentukan arah pembicaraan
+ [Bukti: CASE PAK ADAM: "KEBERSIHAN" ]
    Pemain: "Ini pak bukti yang bapak minta." #Player
    Pemain: "Tadi ada yang mengeluh gatal-gatal parah karena sanitasi pabrik yang kacau, katanya sampai ada bangkai tikus seminggu yang tidak dibersihkan." #Player
    Pemain: "Petugas kebersihan juga katanya cuma fokus di kantor pusat saja sekarang." #Player
    Bos: "Waduh, kalau sanitasi buruk begitu bisa bahaya buat kesehatan mereka. Ada keluhan lain?" #NPC
    -> lanjutan_bukti_pengadilan_pertama

+ [Bukti: CASE IBU DENIS: "KORUPSI" ]
    Pemain: "Ini pak bukti yang bapak minta." #Player
    Bos: "Apa ini? Bukan ini yang aku maksud!" #NPC
    -> pilihan_bukti_pengadilan_pertama

=== lanjutan_bukti_pengadilan_pertama ===
* [Lanjutkan investigasi]
Pemain memberikan rekaman. #Narrative
-> percakapan_lanjutan

=== percakapan_lanjutan ===
Pemain: "Ada lagi soal jam kerja, Bos. Mereka dipaksa kerja lebih dari 12 jam, kalau tidak mau mereka terancam bakal kehilangan pekerjaan." #Player

+ [Balas: "Bahkan perlengkapan keamanan..."]
Pemain: "Bahkan perlengkapan keamanan seperti rompi saja sudah sobek-sobek dan tidak diganti, padahal itu kan hak mereka." #Player

Bos: "Waduh, kalau sampai APD tidak diatur dengan baik, itu pasti ada kesalahan di manajemen. " #NPC

Bos: "Tapi jujur saja, saya masih belum yakin ini masalah di satu divisi saja atau memang bobrok di seluruh sistem pabriknya." #NPC

Bos: "Harusnya perusahaan sudah mengikuti peraturan yang ada." #NPC
-> percakapan_resolusi

=== percakapan_resolusi ===
+ [Balas: "Saya belum tahu..."]
Pemain: "Saya belum tahu penyebab kurangnya pemeliharaan fasilitas buruh itu, Bos." #Player

Bos: "Begini saja, saya belum bisa ambil kesimpulan cuma dari cerita ini. Kamu coba telusuri lagi pelan-pelan. " #NPC

Bos: "Cari informasi lebih detail lagi langsung dari buruh-buruh itu saat mereka datang ke warung! Kita perlu tahu apa sumber masalah dari semua ini." #NPC
-> penutup

=== penutup ===
+ ["Siap,Bos"]
    Pemain: "Siap, Bos. Nanti saya coba ajak ngobrol lagi kalau mereka datang." #Player
    Bos: "Bagus. Saya tunggu laporannya." #NPC
    -> END