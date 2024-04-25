Low Precision Formula for Sun Position
Algorithm from the Astronomical Almanac, page C5 (2017 ed). Accuracy 1deg from 1950-2050.

𝑛 = 𝑗𝑑 − 2451545.0
𝐿 = 280.460 + 0.9856474𝑛
𝑔 = 357.528 + .9856003𝑛
𝜆 = 𝐿 + 1.915sin 𝑔 + 0.020 sin 2𝑔
𝛽 = 0.0
𝜖 = 23.439 − 0.0000004𝑛
cos 𝜆 tan 𝛼 = cos 𝜖 sin 𝜆
sin 𝛿 = sin 𝜖 sin 𝜆

Where λ is the ecliptic longitude, 
β is the ecliptic latitude (always 0), 
α is the Right Ascension, and 
δ is the Declination.