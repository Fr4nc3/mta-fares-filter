import db
import uuid

sql_file = 'sql/fhv_2018_01.sql'
sql_writer = open(sql_file, "w+")
count = 0
car_type = '"{}"'.format('fhv')
with open('csv/fhv_tripdata_2018-01.csv', 'r') as f:
    for line in f:
        line = line.strip()
        x = line.split(',')
        trip_id = '"{}"'.format(uuid.uuid1())  # unique id for the trip
        pickup_borough = x[3] if x[3] != '""' else '"{}"'.format(265)
        dropoff_borough = x[4] if x[4] != '""' else '"{}"'.format(265)
        rate_code_id = '"{}"'.format(1)  # default
        fare_amount = '"{}"'.format(0.000)  # default
        passenger_count = '"{}"'.format(1)  # default
        sr_flag = x[5] if x[5] != '""' else '"{}"'.format(0)
        pay_type = '"{}"'.format(5)  # unknown
        trip_distance = '"{}"'.format(0.000)  # default
        start_date = x[1]
        end_date = x[2]
        if 1 < count:  # avoid header
            sql_writer.write(db.sql_insert.format(trip_id, car_type, pickup_borough, dropoff_borough,
                                                  rate_code_id, fare_amount, passenger_count, sr_flag,
                                                  pay_type, trip_distance, start_date, end_date))

        count += 1
