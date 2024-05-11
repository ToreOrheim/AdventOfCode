use std::{fs::File, io::BufReader};

fn main() {
    let file = File::open("in.json").expect("Could not open file");
    let file_buffer = BufReader::new(file);
    let encrypted_calibration_values: Vec<String> =
        serde_json::from_reader(file_buffer).expect("Could not read");

    let decrypted: i32 = sum_of_calibration_values(encrypted_calibration_values);
    println!("Sum of calibration values: {:?}", decrypted);
}

fn sum_of_calibration_values(encrypted_calibration_values: Vec<String>) -> i32 {
    let mut sum_of_decoded_values: i32 = 0;
    for encrypted_calibration_value in encrypted_calibration_values {
        let numbers_from_string = extract_numbers_from_string(encrypted_calibration_value);
        sum_of_decoded_values +=
            turn_first_and_last_digit_into_two_digit_number(numbers_from_string);
    }
    return sum_of_decoded_values;
}

fn extract_numbers_from_string(encoded_string: String) -> Vec<i32> {
    let split_string = encoded_string.split("");
    let mut parsed_values: Vec<i32> = vec![];
    for char in split_string {
        let value = char.parse::<i32>();
        match value {
            Ok(x) => parsed_values.push(x),
            Err(_) => (),
        }
    }
    return parsed_values;
}

fn turn_first_and_last_digit_into_two_digit_number(num: Vec<i32>) -> i32 {
    return num.first().unwrap() * 10 + num.last().unwrap();
}
