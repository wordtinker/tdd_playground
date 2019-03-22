use r_tdd::core::adder;
// code in tests folder won't be compiled except by 'cargo test'
// #[cfg(test)] not needed
#[test]
fn adder_twoplustwo_four() {

    let result: i32 = adder(2, 2);

    assert_eq!(4, result);
}