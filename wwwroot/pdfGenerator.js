window.generatePdf = (surveyTitle, questions) => {
    const { jsPDF } = window.jspdf;
    const doc = new jsPDF();

    // Set up document properties
    doc.setFont("helvetica", "bold");
    doc.setFontSize(20);
    doc.text(surveyTitle, 10, 20);

    let yPosition = 30;

    doc.setFont("helvetica", "normal");
    doc.setFontSize(12);

    questions.forEach((question, index) => {
        // Add a star (*) for required questions
        let questionTitle = `${index + 1}. ${question.title}`;
        if (question.isRequired) {
            questionTitle += " *";
        }

        // Question Title
        doc.setFontSize(14);
        doc.text(questionTitle, 10, yPosition);
        yPosition += 10;
        doc.setFontSize(12);
        if (question.type === "SingleChoice") {
            // Single Choice Answers
            question.answers.forEach((answer) => {                
                doc.circle(20, yPosition - 2, 2); // Circle for single choice
                doc.text(answer, 25, yPosition);
                yPosition += 10;
            });
        } else if (question.type === "MultipleChoice") {
            // Multiple Choice Answers
            question.answers.forEach((answer) => {
                doc.rect(18, yPosition - 4, 4, 4); // Square for multiple choice, adjusted position
                doc.text(answer, 25, yPosition);
                yPosition += 10;
            });
        } else if (question.type === "OpenEnded") {
            // Open-Ended Questions
            doc.text("____________________________________________________________", 20, yPosition);
            yPosition += 10;
            doc.text("____________________________________________________________", 20, yPosition);
            yPosition += 10;
            doc.text("____________________________________________________________", 20, yPosition);
            yPosition += 15; // Extra space after open-ended questions
        }

        yPosition += 5; // Space between questions
    });

    doc.save(`${surveyTitle}.pdf`);
};
