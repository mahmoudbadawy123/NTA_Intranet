export class ValidPatterns {
    public static ONE_AE_AlPHAB = '[a-zA-Zء-ي]';
    public static WORDS_AE_ONLY = '[a-zA-Zء-ي ]+'; // space in pattern to validate space hhhh
    public static MOBILE = '01(0|1|2|5)[0-9]{8}';
    public static Int = '[0-9]+';
}
