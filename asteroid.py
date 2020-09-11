# -----------------------------------------------------------------------------
import ephem
import math
# -----------------------------------------------------------------------------
def substring(str, start, count):
  return str[start - 1:start - 1 + count].strip();
# -----------------------------------------------------------------------------

filepath = "astorb.dat"

with open(filepath) as fp:

	line = fp.readline()

	print("int[][] data = new int[][]")
	print("{")

	while line:

		asteroid_number = substring(line, 1, 6)
		name = substring(line, 8, 18)
		H = substring(line, 43, 5)
		G = substring(line, 49, 5)
		epoch_osculation_year = substring(line, 107, 4)
		epoch_osculation_month = substring(line, 111, 2)
		epoch_osculation_day = substring(line, 113, 2)
		mean_anomaly = substring(line, 116, 10)
		argument_perihelion = substring(line, 127, 10)
		longitude_ascending_node = substring(line, 138, 10) 
		inclination = substring(line, 149, 9)  
		eccentricity = substring(line, 159, 10)  
		semimajor_axis = substring(line, 170, 12)  

		# print(asteroid_number)
		# print(name)
		# print(H)
		# print(G)
		# print(epoch_osculation_year)
		# print(epoch_osculation_month)
		# print(epoch_osculation_day)
		# print(mean_anomaly)
		# print(argument_perihelion)
		# print(longitude_ascending_node)
		# print(inclination)
		# print(eccentricity)
		# print(semimajor_axis)

		xephem = "(" + asteroid_number + ") " + name + "," \
						 + "e" + "," + inclination + "," + longitude_ascending_node + "," + argument_perihelion + "," + semimajor_axis + ",," \
						 + eccentricity + "," + mean_anomaly + "," + epoch_osculation_month + "/" + epoch_osculation_day + "/" + epoch_osculation_year + "," \
						 + "2000" + "," + H + "," + G + ","

		yh = ephem.readdb(xephem)

		date_time_1 = "2020/07/24 02:46:00UTC"
		yh.compute(date_time_1)
		ra_1 = float(yh.a_ra) * 180 / math.pi
		dec_1 = float(yh.a_dec) * 180 / math.pi

		ra_search = 312.825
		dec_search = -14.280
		ra_delta_search = 0.400
		dec_delta_search = 0.200

		if (ra_1 >= ra_search - ra_delta_search) and \
			 (ra_1 <= ra_search + ra_delta_search) and \
			 (dec_1 >= dec_search - dec_delta_search) and \
			 (dec_1 <= dec_search + dec_delta_search):

			date_time_4 = "2020/07/24 03:36:00UTC"
			yh.compute(date_time_4)
			ra_4 = float(yh.a_ra) * 180 / math.pi
			dec_4 = float(yh.a_dec) * 180 / math.pi

			print("new int[] { ", int(ra_1 * 1000), ",", int(dec_1 * 1000), ",", int(ra_4 * 1000), ",", int(dec_4 * 1000), "},", "// ", yh.name, " | ", yh.mag)

			#print("======================================");
			#print(yh.name)
			#print(yh.mag)
			#print("======================================");
			#print("TIME:", date_time_1);
			#print("RA:", ra_1)
			#print("DEC:", dec_1)
			#print("--------------------------------------");
			#print("TIME:", date_time_4);
			#print("RA:", ra_4)
			#print("DEC:", dec_4)
			#print("--------------------------------------");
			#print("DELTA_RA:", ra_1 - ra_4)
			#print("DELTA_DEC:", dec_1 - dec_4)
			#print("--------------------------------------");

		line = fp.readline()

	print("};")
