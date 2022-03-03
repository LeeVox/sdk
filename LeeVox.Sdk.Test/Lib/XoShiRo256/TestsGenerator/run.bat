@echo off

rem build
call mvn clean dependency:copy-dependencies package

rem run generator
call java -cp "target/dependency/commons-rng-core-1.3.jar;target/dependency/commons-rng-simple-1.3.jar;target/dependency/commons-rng-client-api-1.3.jar;target/generator-1.0.jar" com.leevox.random.xoshiro.generator.app

@echo on