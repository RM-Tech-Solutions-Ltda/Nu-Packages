using FluentAssertions;

namespace RMTech.TestPackage.UnitTests;

public class ArrayUtilsTest
{
    [Theory]
    [InlineData(new int[] {1, 2, 3, 2, 1}, 3)]
    [InlineData(new int[] {1, 2, 3, 4, 3, 2, 1}, 4)]
    public void SingleNumber_ReceivesValidArray_ReturnsSingle(int[] nums, int expectedSingle)
        => ArrayUtils.SingleNumber(nums).Should().Be(expectedSingle);

    [Theory]
    [InlineData(new int[] {1, 2, 3, 2, 1}, 3)]
    [InlineData(new int[] {1, 2, 3, 4, 3, 2, 1}, 4)]
    public void SingleNumberWithComments_ReceivesValidArray_ReturnsSingleValueWithCommentsOfSteps
        (int[] nums, int expectedSingle) 
            => ArrayUtils.SingleNumberWithComments(nums).Should().Be(expectedSingle);
}
