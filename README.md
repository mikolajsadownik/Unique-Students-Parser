# Unique Students Parser

## Overview

**Unique Students Parser** is a Python application that reads a CSV file with student records, filters out duplicates and erroneous entries, and saves the cleaned data into a JSON file. This application ensures that each student is unique and combines study programs for students already included in the file.

## Features

- **Input File Parsing:** Reads student data from a CSV file.
- **Duplicate Filtering:** Detects unique students based on the student number (starting with "s"), name, surname, study program name, and study mode.
- **Error Handling:** Logs errors to `log.txt` for records that don't have all required 9 fields.
- **Program Aggregation:** Consolidates study programs of the same student.
- **Unique Index Prefix:** Ensures every student's index starts with "s".
- **Output to JSON:** Saves the filtered, aggregated data to a JSON file.

## Usage

### Arguments

1. **Input File Path:** Path to the CSV file containing student data.
2. **Output File Path:** Path to save the output JSON file.

### Example Command

```bash
python unique_students_parser.py input.csv output.json
