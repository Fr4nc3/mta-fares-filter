
sql_insert = "INSERT INTO data_trip (" \
             "trip_id,car_type,pickup_borough,dropoff_borough,rate_code_id,fare_amount,passenger_count,sr_flag," \
             "pay_type,trip_distance,start_date, end_date) " \
             "VALUES ({},{},{},{},{},{}," \
             "{},{}, {},{},{}, {});\n"
