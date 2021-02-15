import db
import uuid

sql_file = 'sql/yellow_2018_01.sql'
sql_writer = open(sql_file, "w+")
count = 0
car_type = '"{}"'.format('yellow')
with open('csv/yellow_tripdata_2018-01.csv', 'r') as f:
    for line in f:
        line = line.strip()
        x = line.split(',')
        if len(x) < 10:  # if the line doesn't match the array structure
            continue
        trip_id = '"{}"'.format(uuid.uuid1())  # unique id for the trip
        pickup_borough = '"{}"'.format(x[7]) if x[7] != '' else '"{}"'.format(265)
        dropoff_borough = '"{}"'.format(x[8]) if x[8] != '' else '"{}"'.format(265)
        rate_code_id = '"{}"'.format(x[5])
        fare_amount = '"{}"'.format(x[10])
        passenger_count = '"{}"'.format(x[3])
        sr_flag = '"{}"'.format(0)
        pay_type = '"{}"'.format(x[9])
        trip_distance = '"{}"'.format(x[4])
        start_date = '"{}"'.format(x[1])
        end_date = '"{}"'.format(x[2])
        if 1 < count:  # avoid header sample
            sql_writer.write(db.sql_insert.format(trip_id, car_type, pickup_borough, dropoff_borough,
                                                  rate_code_id, fare_amount, passenger_count, sr_flag,
                                                  pay_type, trip_distance, start_date, end_date))

        count += 1
